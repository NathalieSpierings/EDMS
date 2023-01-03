using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Promeetec.EDMS.Configuration;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Domain.Models.Modules.Ketenzorg;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Modules.Ketenzorg.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.QueryHandlers;

public class GetKetenzorgFacturenHandler : IQueryHandlerAsync<GetKetenzorgFacturen, KetenzorgFacturenViewModel>
{
    private readonly IOrganisatieRepository _repository;
    private readonly IOptions _options;

    public GetKetenzorgFacturenHandler(IOrganisatieRepository repository, IOptions options)
    {
        _repository = repository;
        _options = options;
    }

    public async Task<KetenzorgFacturenViewModel> HandleAsync(GetKetenzorgFacturen query)
    {
        var adres = _repository.GetOrganisatieAddressById(query.OrganisatieId);

        var model = new KetenzorgFacturenViewModel
        {
            OrganisatieId = query.OrganisatieId,
            OrganisatieNummer = query.OrganisatieNummer,
            OrganisatieNaam = query.OrganisatieNaam,
            OrganisatieHasAnAddress = adres != null
        };

        try
        {
            var url = $"{_options.KetenzorgApiBaseUrl}/api/ketenzorg/ketenpartners/{query.OrganisatieNummer}/invoicePeriods";

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

                model.Facturen = JsonConvert.DeserializeObject<List<InvoicePeriod>>(result).Select(x => new MachtigingFacturenListItemViewModel
                {
                    Id = x.Id,
                    FactuurNummer = x.InvoiceNumber,
                    Naam = $"Factuur {x.Enddate.Month}-{x.Enddate.Year}",
                    Periode = $"{x.Startdate:dd-MM-yyyy} - {x.Enddate:dd-MM-yyyy}",
                    AangemaaktOp = x.CreatedOn
                }).ToList();
            }
            else
            {
                var result = await response.Content.ReadAsStringAsync();
                var logger = Logging.Logger.Instance;
                logger.Error($"GetKetenzorgFacturenHandler: Kan facturen niet ophalen via ketenzorg api!  Response: {response.StatusCode} | {result}");
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