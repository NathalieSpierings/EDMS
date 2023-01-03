using System;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using Promeetec.EDMS.Configuration;
using Promeetec.EDMS.Domain.Models.Modules.ION;
using Promeetec.EDMS.Extensions;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Modules.ION.Models;
using Promeetec.EDMS.Reporting.Private.Modules.ION.Models;
using Promeetec.EDMS.Reporting.Private.Modules.ION.Queries;
using Promeetec.EDMS.Vecozo.ION;
using Promeetec.EDMS.Vecozo.ION.IONServiceReference;
using Kwaliteitscategorie = Promeetec.EDMS.Vecozo.ION.IONServiceReference.Kwaliteitscategorie;

namespace Promeetec.EDMS.Reporting.Private.Modules.ION.QueryHandlers;

public class GetIONPopulatieHandler : IQueryHandlerAsync<GetIONPopulatie, IONPopulatieViewModel>
{
    private readonly IOptions _options;

    public GetIONPopulatieHandler(IOptions options)
    {
        _options = options;
    }

    public async Task<IONPopulatieViewModel> HandleAsync(GetIONPopulatie query)
    {
        await Task.CompletedTask;

        var model = new IONPopulatieViewModel
        {
            MedewerkerId = query.MedewerkerId,
            OrganisatieId = query.OrganisatieId
        };

        if (string.IsNullOrEmpty(query.Periode) || string.IsNullOrEmpty(query.AgbCodeZorgverlener) || string.IsNullOrEmpty(query.AgbCodeOnderneming))
            return model;

        var kwartaalJaar = Convert.ToInt32(query.Periode.Substring(0, 4));
        var kwartaal = Convert.ToInt32(query.Periode.Substring(6));
        var peildatum = kwartaal.GetFirstDayOfQuarterByQuarterNumber(kwartaalJaar);
        var agbCodeZorgverlener = Convert.ToInt32(query.AgbCodeZorgverlener.Substring(2));
        var zorgverlenerSoort = Convert.ToInt32(query.AgbCodeZorgverlener.Substring(0, 2));
        var agbCodePraktijk = Convert.ToInt32(query.AgbCodeOnderneming.Substring(2));
        var praktijkSoort = Convert.ToInt32(query.AgbCodeOnderneming.Substring(0, 2));

        // Stel zoekopdracht samen
        var zoekOpdracht = new OpvragenActievePatientrelatiesRequest
        {
            Peildatum = peildatum,
            Kwaliteitscategorie = Kwaliteitscategorie.WelBsnWelVerzekering,
        };

        switch (query.IONZoekOptie)
        {
            case IONZoekOptie.ZoekenOpPraktijk:
                zoekOpdracht.Zoekoptie = OpvragenActievePatientrelatiesZoekoptie.ZoekenOpPraktijk;
                zoekOpdracht.Zorgaanbieder = new ZorgaanbiederIdentificatie
                {
                    Praktijk = new AgbCode
                    {
                        Nummer = agbCodePraktijk,
                        Soort = praktijkSoort
                    }
                };
                break;
            case IONZoekOptie.ZoekenOpZorgverlener:
                zoekOpdracht.Zoekoptie = OpvragenActievePatientrelatiesZoekoptie.ZoekenOpZorgverlener;
                zoekOpdracht.Zorgaanbieder = new ZorgaanbiederIdentificatie
                {
                    Zorgverlener = new AgbCode
                    {
                        Nummer = agbCodeZorgverlener,
                        Soort = zorgverlenerSoort
                    },
                    Praktijk = new AgbCode
                    {
                        Nummer = agbCodePraktijk,
                        Soort = praktijkSoort
                    }
                };
                break;
            case IONZoekOptie.ZoekenOpPraktijkEnGekoppeldeZorgverleners:
                zoekOpdracht.Zoekoptie = OpvragenActievePatientrelatiesZoekoptie.ZoekenOpPraktijkEnGekoppeldeZorgverleners;
                zoekOpdracht.Zorgaanbieder = new ZorgaanbiederIdentificatie
                {
                    Praktijk = new AgbCode
                    {
                        Nummer = agbCodePraktijk,
                        Soort = praktijkSoort
                    }
                };
                break;
        }

        // Initieer de ION service
        var service = new IONService();

        var client = service.Init(_options, query.Omgeving);
        client.Open();

        var actievePatientRelaties = new PatientrelatieCollection();
        var response = service.OpvragenActievePatientRelaties(zoekOpdracht);
        var aantalRelaties = response.AantalResultaten;

        // We krijgen altijd de 1e 500 resultaten terug.
        actievePatientRelaties.AddRange(response.ActieveRelaties);

        for (var i = 1; i <= (aantalRelaties - 1) / 500; i++)
        {
            var vanaf = i * 500 + 1;
            zoekOpdracht.VanafResultaat = vanaf;
            actievePatientRelaties.AddRange(service.OpvragenActievePatientRelaties(zoekOpdracht).ActieveRelaties);
        }

        client.Close();

        var relaties = actievePatientRelaties.Select(x => new IONPatient
        {
            Key = x.RelatieId,
            RelatieId = x.RelatieId,
            Bsn = x.Patient.Bsn,
            Geboortedatum = x.Patient.Geboortedatum,
            Voorletters = x.Patient.Voorletters,
            Tussenvoegsel = x.Patient.Tussenvoegsel,
            Achternaam = x.Patient.Achternaam,
            Kwaliteitscategorie = "WelBsnWelVerzekering",
            PatientrelatiesZoekoptie = query.IONZoekOptie.GetDisplayName(),
            AgbCodePraktijk = query.AgbCodeOnderneming
        }).ToList();

        model.Zoekopdracht = new IONZoekopdrachtViewModel
        {
            Periode = query.Periode,
            AgbCodeZorgverlener = query.AgbCodeZorgverlener,
            AgbCodeOnderneming = query.AgbCodeOnderneming,
            Periodes = new SelectList(DateTime.Today.GetListOfQuarters().ToList(), "Key", "Value")
        };
        model.AantalRelaties = aantalRelaties;
        model.Relaties = relaties;

        return model;
    }
}