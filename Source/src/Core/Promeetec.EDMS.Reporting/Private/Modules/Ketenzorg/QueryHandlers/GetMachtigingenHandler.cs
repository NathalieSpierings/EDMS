using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Promeetec.EDMS.Configuration;
using Promeetec.EDMS.Domain.Models.Modules.Ketenzorg;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.QueryHandlers;

public class GetMachtigingenHandler : IQueryHandlerAsync<GetMachtigingen, MachtigingenViewModel>
{
    private readonly IOptions _options;

    public GetMachtigingenHandler(IOptions options)
    {
        _options = options;
    }

    public async Task<MachtigingenViewModel> HandleAsync(GetMachtigingen query)
    {
        var model = new MachtigingenViewModel
        {
            OrganisatieId = query.OrganisatieId,
            OrganisatieNaam = query.OrganisatieNaam,
            OrganisatieNummer = query.OrganisatieNummer
        };

        try
        {
            var url = $"{_options.KetenzorgApiBaseUrl}/api/ketenzorg/ketenpartners/{query.OrganisatieNummer}/authorizations?include=product&include=registrations";

            HttpResponseMessage response;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                response = client.GetAsync(url).Result;
            }

            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();

                var machtigingen = JsonConvert.DeserializeObject<List<Authorization>>(result).Select(x => new MachtigingenListItemViewModel
                {
                    Id = x.Id,
                    OrganisatieId = query.OrganisatieId,
                    OrganisatieNaam = query.OrganisatieNaam,
                    OrganisatieNummer = query.OrganisatieNummer,
                    Geboortedatum = x.PatientBirthdate,
                    Voorletters = x.PatientInitials,
                    Tussenvoegsel = x.PatientOwnNamePrefix,
                    Achternaam = x.PatientOwnName,
                    TussenvoegselPartner = x.PatientPartnerNamePrefix,
                    AchternaamPartner = x.PatientPartnerName,
                    Startdatum = x.Startdate,
                    Einddatum = x.Enddate,
                    Status = (MachtigingStatus)x.State,
                    Naam = x.Product.Name,
                    ZdNummer = x.ZDNumber
                }).ToList();

                // Zoeken
                if (!string.IsNullOrWhiteSpace(query.SearchTerm))
                {
                    var matchWoorden = query.SearchTerm.ToLower().Split(' ');
                    foreach (var match in matchWoorden)
                    {
                        if (DateTime.TryParse(match, out var date))
                        {
                            machtigingen = machtigingen.Where(x => (x.Einddatum.HasValue
                                                                       ? x.Einddatum.Value.ToShortDateString() == date.ToShortDateString()
                                                                       : x.Startdatum.ToShortDateString() == date.ToShortDateString()) ||
                                                                   x.Geboortedatum.ToShortDateString() == date.ToShortDateString()).ToList();
                        }
                        else
                        {
                            machtigingen = machtigingen.Where(x => machtigingen.Any(y => x.FormeleNaam.ToLowerInvariant().Contains(match)) ||
                                                                   machtigingen.Any(y => x.Naam.ToLowerInvariant().Contains(match)) ||
                                                                   machtigingen.Any(y => x.ZdNummer.ToLowerInvariant().Contains(match))).ToList();
                        }
                    }
                }

                model.Machtigingen = machtigingen.ToList();
            }
            else
            {
                var result = await response.Content.ReadAsStringAsync();
                var logger = Logging.Logger.Instance;
                logger.Error($"GetMachtigingenHandler: Kan machtigingen niet ophalen via ketenzorg api!  Response: {response.StatusCode} | {result}");
                model.ApiError = "Fout opgetreden! Uw gegevens kunnen niet opgehaald worden. Sluit uw browser en probeer het nogmaals. Bij aanhoudende problemen neem dan contact op met Promeetec.";
            }

            return model;
        }
        catch (Exception ex)
        {
            var logger = Logging.Logger.Instance;
            logger.Error("Ketenzorg API niet bereikbaar.", ex);
            model.ApiError = "Fout opgetreden! Uw gegevens kunnen niet opgehaald worden. Neem contact op met Promeetec!";
            return model;
        }
    }
}