using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Adres.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Persoon.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Verzekerde.Models;
using Promeetec.EDMS.Reporting.Modules.Verbruiksmiddel.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.QueryHandlers;

public class GetVerzekerdeCreateHandler : IQueryHandlerAsync<GetVerzekerdeCreate, VerzekerdeCreateViewModel>
{
    private readonly IVerzekerdeRepository _repository;

    public GetVerzekerdeCreateHandler(IVerzekerdeRepository repository)
    {
        _repository = repository;
    }

    public async Task<VerzekerdeCreateViewModel> HandleAsync(GetVerzekerdeCreate query)
    {
        var dbQuery = await _repository.Query()
            .AsNoTracking()
            .Where(x => x.Id == query.VerzekerdeId)
            .FirstOrDefaultAsync();

        var model = new VerzekerdeCreateViewModel
        {
            Id = dbQuery.Id,
            AdresboekId = dbQuery.AdresboekId,
            Status = dbQuery.Status,
            Shared = dbQuery.Shared,
            Bsn = dbQuery.Bsn,
            Lengte = dbQuery.Lengte,
            Organisatie = new OrganisatieViewModel
            {
                Id = dbQuery.Adresboek.Organisatie.Id,
                VerwijzerInAdresboek = dbQuery.Adresboek.Organisatie.VerwijzerInAdresboek
            },
            AgbCodeVerwijzer = dbQuery.AgbCodeVerwijzer,
            NaamVerwijzer = dbQuery.NaamVerwijzer,
            Verwijsdatum = dbQuery.Verwijsdatum,
            Persoon = new PersoonCreateEditViewModel
            {
                Geslacht = dbQuery.Persoon.Geslacht,
                Geboortedatum = dbQuery.Persoon.Geboortedatum ?? DateTime.MinValue,
                Voorletters = dbQuery.Persoon.Voorletters,
                Voornaam = dbQuery.Persoon.Voornaam,
                Tussenvoegsel = dbQuery.Persoon.Tussenvoegsel,
                Achternaam = dbQuery.Persoon.Achternaam,
                FormeleNaam = dbQuery.Persoon.FormeleNaam,
                VolledigeNaam = dbQuery.Persoon.VolledigeNaam
            },
            Adres = new AdresCreateEditViewModel
            {
                Straat = dbQuery.Adres.Straat,
                Postcode = dbQuery.Adres.Postcode,
                Huisnummer = dbQuery.Adres.Huisnummer,
                HuisnummerToevoeging = dbQuery.Adres.Huisnummertoevoeging,
                Woonplaats = dbQuery.Adres.Woonplaats,
                LandId = dbQuery.Adres.LandId.Value,
                WoonachtigOp = dbQuery.Adres.WoonachtigOp,
                WoonachtigTot = dbQuery.Adres.WoonachtigTot
            },
            Zorgverzekering = new ZorgverzekeringCreateViewModel
            {
                PatientNummer = dbQuery.Zorgverzekering.PatientNummer,
                VerzekerdeNummer = dbQuery.Zorgverzekering.VerzekerdeNummer,
                VerzekeraarId = dbQuery.Zorgverzekering.Verzekeraar.Id,
                VerzekerdOp = dbQuery.Zorgverzekering.VerzekerdOp,
                VerzekerdTot = dbQuery.Zorgverzekering.VerzekerdTot
            },
            Zorgprofiel = dbQuery.Zorgprofiel != null ?
                new ZorgprofielViewModel
                {
                    ProfielCode = dbQuery.Zorgprofiel.ProfielCode,
                    ProfielStartdatum = dbQuery.Zorgprofiel.ProfielStartdatum,
                    ProfielEinddatum = dbQuery.Zorgprofiel.ProfielEinddatum ?? dbQuery.Zorgprofiel.ProfielEinddatum
                }
                : new ZorgprofielViewModel(),
            AangemaaktDoorId = dbQuery.AangemaaktDoorId,
            AangemaaktOp = dbQuery.AangemaaktOp,
            AangemaaktDoor = dbQuery.AangemaaktDoor,
            CollegaIds = dbQuery.Users.Select(y => y.UserId).ToList(),
        };
        return model;
    }
}