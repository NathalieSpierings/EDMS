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
using Authorization = Promeetec.EDMS.Domain.Models.Modules.Ketenzorg.Authorization;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.QueryHandlers;

public class GetMachtigingHandler : IQueryHandlerAsync<GetMachtiging, MachtigingViewModel>
{
    private readonly IOptions _options;

    public GetMachtigingHandler(IOptions options)
    {
        _options = options;
    }

    public async Task<MachtigingViewModel> HandleAsync(GetMachtiging query)
    {
        var model = new MachtigingViewModel
        {
            Id = query.MachtigingId,
            OrganisatieId = query.OrganisatieId,
            OrganisatieNaam = query.OrganisatieNaam
        };

        try
        {
            var url = query.IncludeRegistraties
                ? $"{_options.KetenzorgApiBaseUrl}/api/ketenzorg/ketenpartners/{query.OrganisatieNummer}/authorizations/{query.MachtigingId}?include=product&include=registrations"
                : $"{_options.KetenzorgApiBaseUrl}/api/ketenzorg/ketenpartners/{query.OrganisatieNummer}/authorizations/{query.MachtigingId}?include=product";

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
                var machtiging = JsonConvert.DeserializeObject<Authorization>(result);
                if (machtiging != null)
                {
                    model.Id = machtiging.Id;
                    model.OrganisatieId = query.OrganisatieId;
                    model.OrganisatieNaam = query.OrganisatieNaam;
                    model.OrganisatieNummer = query.OrganisatieNummer;
                    model.ZDNummer = machtiging.ZDNumber;
                    model.AgbcodeVerwijzer = machtiging.ReferringPractitionerAGB;
                    model.NaamVerwijzer = machtiging.ReferringPractitionerName;
                    model.Voorletters = machtiging.PatientInitials;
                    model.Tussenvoegsel = machtiging.PatientOwnNamePrefix;
                    model.Achternaam = machtiging.PatientOwnName;
                    model.TussenvoegselPartner = machtiging.PatientPartnerNamePrefix;
                    model.AchternaamPartner = machtiging.PatientPartnerName;
                    model.Geboortedatum = machtiging.PatientBirthdate;
                    model.Bsn = machtiging.PatientBSN;
                    model.Startdatum = machtiging.Startdate;
                    model.Einddatum = machtiging.Enddate;
                    model.Status = (MachtigingStatus)machtiging.State;
                    model.MaxRegistrationRetroPeriodDays = machtiging.MaxRegistrationRetroPeriodDays;
                    model.Product = new MachtigingProductViewModel
                    {
                        Id = machtiging.Product.Id,
                        Naam = machtiging.Product.Name,
                        ActiviteitGroepen = machtiging.Product.ActivityGroups.Select(x => new MachtigingActiviteitGroepViewModel
                        {
                            Id = x.Id,
                            MaxAantal = x.MaxQuantity,
                            ResterendAantal = x.MaxQuantity,
                            Activiteiten = x.Activities.Select(y => new MachtigingProductActiviteitViewModel
                            {
                                Id = y.Id,
                                ActiviteitId = y.Id,
                                Eenheid = (ZorgproductEenheid)y.Unit,
                                Naam = y.Name,
                                Tarief = y.Tariff,
                                Opmerking = y.Remark
                            }).ToList()
                        }).ToList()
                    };

                    if (query.IncludeRegistraties)
                    {
                        model.Registraties = machtiging.Registrations.OrderBy(o => o.CreatedOn).Select(x => new MachtigingRegistratieViewModel
                        {
                            Id = x.Id,
                            MachtigingId = query.MachtigingId,
                            ActiviteitId = x.ActivityId,
                            Behandeldatum = x.TreatmentDate,
                            Registratiedatum = x.CreatedOn,
                            Aantal = x.Quantity,
                            Verwerkt = x.Processed,
                            Credit = new MachtigingRegistratieViewModel
                            {
                                Id = x.Credit?.Id ?? Guid.Empty,
                                MachtigingId = query.MachtigingId,
                                ActiviteitId = x.Credit?.ActivityId ?? Guid.Empty,
                                Behandeldatum = x.Credit?.TreatmentDate ?? DateTime.MinValue,
                                Registratiedatum = x.Credit?.CreatedOn ?? DateTime.MinValue,
                                Aantal = x.Credit?.Quantity ?? 0,
                                Verwerkt = x.Credit?.Processed ?? false,
                            }
                        }).ToList();

                        // Vul de registraties aan
                        foreach (var registratie in model.Registraties)
                        {
                            var currentGroup = model.Product.ActiviteitGroepen.FirstOrDefault(x => x.Activiteiten.Any(y => y.Id == registratie.ActiviteitId));
                            var currentActiviteit = currentGroup.Activiteiten.FirstOrDefault(x => x.Id == registratie.ActiviteitId);

                            registratie.ActiviteitGroepId = currentGroup.Id;
                            registratie.Eenheid = currentActiviteit.Eenheid;
                            registratie.Tarief = currentActiviteit.Tarief;
                            registratie.Naam = currentActiviteit.Naam;
                            registratie.Opmerking = currentActiviteit.Opmerking;
                            registratie.MaxAantal = currentGroup.MaxAantal;


                            int resterend = Math.Max(currentGroup.ResterendAantal - registratie.Aantal, 0);

                            registratie.ResterendAantal = resterend;
                            currentGroup.ResterendAantal = resterend;

                            if (registratie.Credit.Id != Guid.Empty)
                            {
                                resterend = Math.Max(currentGroup.ResterendAantal - registratie.Credit.Aantal, 0);
                                registratie.ResterendAantal = resterend;
                                currentGroup.ResterendAantal = resterend;
                            }
                        }
                    }

                    return model;
                }
            }
            else
            {
                var result = await response.Content.ReadAsStringAsync();
                var logger = Logging.Logger.Instance;
                logger.Error($"GetMachtigingHanlder: Kan machtiging niet ophalen via ketenzorg api!  Response: {response.StatusCode} | {result}");
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


        ////if (response.StatusCode >= (HttpStatusCode)400 && response.StatusCode < (HttpStatusCode)500)
        ////{
        ////    var result = await response.Content.ReadAsStringAsync();
        ////    var error = JsonConvert.DeserializeObject<ApiError>(result);
        ////}
        // return model;
    }
}