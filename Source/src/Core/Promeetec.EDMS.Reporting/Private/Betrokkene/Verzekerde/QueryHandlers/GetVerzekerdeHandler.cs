using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Adres.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Land.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.QueryHandlers;

public class GetVerzekerdeHandler : IQueryHandlerAsync<GetVerzekerde, VerzekerdeViewModel>
{
    private readonly IVerzekerdeRepository _repository;

    public GetVerzekerdeHandler(IVerzekerdeRepository repository)
    {
        _repository = repository;
    }

    public async Task<VerzekerdeViewModel> HandleAsync(GetVerzekerde query)
    {
        var dbQuery = await _repository.Query()
            .AsNoTracking()
            .Include(i => i.Zorgprofielen)
            .Where(x => x.Id == query.VerzekerdeId)
            .FirstOrDefaultAsync();

        var model = new VerzekerdeViewModel
        {
            Id = dbQuery.Id,
            AdresboekId = dbQuery.AdresboekId,
            Organisatie = new OrganisatieViewModel
            {
                Id = dbQuery.Adresboek.Organisatie.Id,
                VerwijzerInAdresboek = dbQuery.Adresboek.Organisatie.VerwijzerInAdresboek,
            },
            Status = dbQuery.Status,
            Shared = dbQuery.Shared,
            Geslacht = dbQuery.Persoon.Geslacht,
            Geboortedatum = dbQuery.Persoon.Geboortedatum ?? default,
            VolledigeNaam = dbQuery.Persoon.VolledigeNaam,
            Achternaam = dbQuery.Persoon.Achternaam,
            Bsn = dbQuery.Bsn,
            Lengte = dbQuery.Lengte,
            AgbCodeVerwijzer = dbQuery.AgbCodeVerwijzer,
            NaamVerwijzer = dbQuery.NaamVerwijzer,
            Verwijsdatum = dbQuery.Verwijsdatum,
            VerzekeraarNaam = dbQuery.Zorgverzekering.Verzekeraar.Naam,
            Uzovi = dbQuery.Zorgverzekering.Verzekeraar.Uzovi.ToString(),
            VerzekerdeNummer = dbQuery.Zorgverzekering.VerzekerdeNummer,
            PatientNummer = dbQuery.Zorgverzekering.PatientNummer,
            ProfielCode = dbQuery.Zorgprofiel?.ProfielCode ?? ProfielCode.Geen,
            ProfielStartdatum = dbQuery.Zorgprofiel?.ProfielStartdatum ?? default,
            ProfielEinddatum = dbQuery.Zorgprofiel?.ProfielEinddatum ?? default,
            Adres = dbQuery.Adres != null ?
                new AdresViewModel
                {
                    Id = dbQuery.Adres.Id,
                    Straat = dbQuery.Adres?.Straat,
                    Huisnummer = dbQuery.Adres?.Huisnummer,
                    HuisnummerToevoeging = dbQuery.Adres?.Huisnummertoevoeging,
                    Postcode = dbQuery.Adres?.Postcode,
                    Woonplaats = dbQuery.Adres?.Woonplaats,
                    LandNaam = dbQuery.Adres?.LandNaam,
                    LandId = dbQuery.Adres?.LandId,
                    WoonachtigOp = dbQuery.Adres?.WoonachtigOp ?? default,
                    WoonachtigTot = dbQuery.Adres?.WoonachtigTot ?? default,
                    Land = dbQuery.Adres?.Land != null ?
                        new LandViewModel
                        {
                            Id = dbQuery.Adres.Land.Id,
                            NativeName = dbQuery.Adres.Land.NativeName
                        }
                        : null
                }
                : new AdresViewModel(),
            AangemaaktDoorId = dbQuery.AangemaaktDoorId,
            AangemaaktOp = dbQuery.AangemaaktOp,
            AangemaaktDoor = dbQuery.AangemaaktDoor,
            Zorgprofielen = dbQuery.Zorgprofielen,
            CollegaIds = dbQuery.Users.Select(y => y.UserId).ToList(),
        };

        return model;
    }
}