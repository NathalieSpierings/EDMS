using System;
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

public class GetKetenzorgFactuurHandler : IQueryHandlerAsync<GetKetenzorgFactuur, KetenzorgFactuurViewModel>
{
    private readonly IOptions _options;

    public GetKetenzorgFactuurHandler(IOptions options)
    {
        _options = options;
    }

    public async Task<KetenzorgFactuurViewModel> HandleAsync(GetKetenzorgFactuur query)
    {
        var model = new KetenzorgFactuurViewModel
        {
            OrganisatieId = query.OrganisatieId,
            OrganisatieNummer = query.OrganisatieNummer,
            OrganisatieNaam = query.OrganisatieNaam
        };

        try
        {
            var url = $"{_options.KetenzorgApiBaseUrl}/api/ketenzorg/ketenpartners/{query.OrganisatieNummer}/invoicePeriods/{query.FactuurId}/invoice";
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
                var factuur = JsonConvert.DeserializeObject<Invoice>(result);


                model.Id = factuur.Id;
                model.FactuurPeriodeId = factuur.InvoicePeriodId;
                model.Factuurnummer = factuur.InvoiceNumber;

                // ketenpartner info
                model.OrganisatieBankrekeningNummer = factuur.Careprovider.BankAccountNumber;
                model.OrganisatieNaam = factuur.Careprovider.Name;

                // Zorggroep info
                model.ZorggroepNaam = factuur.Caregroup.Name;
                model.ZorggroepAgbcode = factuur.Caregroup.Agb;
                model.Footer = factuur.Caregroup.Footer;
                model.Logo = factuur.Caregroup.Logo;

                model.Totaalbedrag = factuur.Total;
                model.AangemaaktOp = factuur.CreatedOn;
                model.DebiteurNummer = factuur.DebitorNumber;

                model.Registraties = factuur.Registrations.Select(x => new FactuurRegistratieViewModel
                {
                    // Patient
                    Voorletters = x.Patient.Initials,
                    Tussenvoegsel = x.Patient.OwnNamePrefix,
                    Achternaam = x.Patient.OwnName,
                    TussenvoegselPartner = x.Patient.PartnerNamePrefix,
                    AchternaamPartner = x.Patient.PartnerName,
                    Geboortedatum = x.Patient.Birthdate,
                    Bsn = x.Patient.BSN,
                    Subtotaal = x.Subtotal,
                    ActiviteitId = x.Id,
                    Behandeldatum = x.TreatmentDate,
                    Naam = x.Activity.Name,
                    Aantal = x.Quantity,
                    Eenheid = (ZorgproductEenheid)x.Activity.Unit,
                    Tarief = x.Tariff
                }).ToList();
            }
            else
            {
                var result = await response.Content.ReadAsStringAsync();
                var logger = Logging.Logger.Instance;
                logger.Error($"GetKetenzorgFactuurHandler: Kan factuur niet ophalen via ketenzorg api!  Response: {response.StatusCode} | {result}");
                model.ApiError = "Fout opgetreden! Uw gegevens kunnen niet opgehaald worden. Sluit uw browser en probeer het nogmaals. Bij aanhoudende problemen neem dan contact op met Promeetec.";
            }

            return model;
        }
        catch (Exception ex)
        {
            var logger = Logging.Logger.Instance;
            logger.Error("GetMachtigingenHandler: Ketenzorg API niet bereikbaar.", ex);
            model.ApiError = "Fout opgetreden! Uw gegevens kunnen niet opgehaald worden. Neem contact op met Promeetec!";
            return model;
        }
    }
}