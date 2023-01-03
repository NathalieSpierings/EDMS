using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Domain.Models.Modules.Adresboek;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Adres.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Land.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Verzekerde.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekerde.QueryHandlers;

public class GetVerzekerdenHandler : IQueryHandlerAsync<GetVerzekerden, VerzekerdenViewModel>
{
    private readonly IAdresboekRepository _adresboekRepository;

    public GetVerzekerdenHandler(IAdresboekRepository adresboekRepository)
    {
        _adresboekRepository = adresboekRepository;
    }

    public async Task<VerzekerdenViewModel> HandleAsync(GetVerzekerden query)
    {
        var model = new VerzekerdenViewModel
        {
            OrganisatieId = query.OrganisatieId
        };

        var adresboek = await _adresboekRepository.Query()
            .AsNoTracking()
            .Include(i => i.Verzekerden)
            .Where(x => x.Id == query.AdresboekId
                        && x.Organisatie.Id == query.OrganisatieId)
            .FirstOrDefaultAsync();


        // Interne user & Adresboek Level 2 gebruikers zien alle clienten uit het adresboek
        if (query.User.IsInterneMedewerker || query.User.IsInRole(RoleNames.ToevoegenClient))
        {
            model.Verzekerden = adresboek.Verzekerden
                .Select(x => new VerzekerdeViewModel
                {
                    Id = x.Id,
                    AdresboekId = x.AdresboekId,
                    Organisatie = new OrganisatieViewModel
                    {
                        Id = x.Adresboek.Organisatie.Id,
                        VerwijzerInAdresboek = x.Adresboek.Organisatie.VerwijzerInAdresboek,
                    },
                    Status = x.Status,
                    Shared = x.Shared,
                    Geslacht = x.Persoon.Geslacht,
                    Geboortedatum = x.Persoon.Geboortedatum ?? default,
                    VolledigeNaam = x.Persoon.VolledigeNaam,
                    Achternaam = x.Persoon.Achternaam,
                    Bsn = x.Bsn,
                    Lengte = x.Lengte,
                    AgbCodeVerwijzer = x.AgbCodeVerwijzer,
                    NaamVerwijzer = x.NaamVerwijzer,
                    Verwijsdatum = x.Verwijsdatum,
                    VerzekeraarNaam = x.Zorgverzekering.Verzekeraar.Naam,
                    Uzovi = x.Zorgverzekering.Verzekeraar.Uzovi.ToString(),
                    VerzekerdeNummer = x.Zorgverzekering.VerzekerdeNummer,
                    PatientNummer = x.Zorgverzekering.PatientNummer,
                    ProfielCode = x.Zorgprofiel?.ProfielCode ?? ProfielCode.Geen,
                    ProfielStartdatum = x.Zorgprofiel?.ProfielStartdatum ?? default,
                    ProfielEinddatum = x.Zorgprofiel?.ProfielEinddatum ?? default,
                    Adres = x.Adres != null ?
                        new AdresViewModel
                        {
                            Id = x.Adres.Id,
                            Straat = x.Adres?.Straat,
                            Huisnummer = x.Adres?.Huisnummer,
                            HuisnummerToevoeging = x.Adres?.Huisnummertoevoeging,
                            Postcode = x.Adres?.Postcode,
                            Woonplaats = x.Adres?.Woonplaats,
                            LandNaam = x.Adres?.LandNaam,
                            LandId = x.Adres?.LandId,
                            WoonachtigOp = x.Adres?.WoonachtigOp ?? default,
                            WoonachtigTot = x.Adres?.WoonachtigTot ?? default,
                            Land = x.Adres?.Land != null ?
                                new LandViewModel
                                {
                                    Id = x.Adres.Land.Id,
                                    NativeName = x.Adres.Land.NativeName
                                }
                                : null
                        }
                        : new AdresViewModel(),
                    AangemaaktDoorId = x.AangemaaktDoorId,
                    AangemaaktOp = x.AangemaaktOp,
                    AangemaaktDoor = x.AangemaaktDoor,
                    CollegaIds = x.Users.Select(y => y.UserId).ToList(),
                    Zorgprofielen = x.Zorgprofielen
                })
                .OrderBy(i => i.Achternaam);
        }
        else
        {
            model.Verzekerden = adresboek.Verzekerden
                .Where(x => x.Users.Any(i => i.UserId == query.User.Id))
                .Select(x => new VerzekerdeViewModel
                {
                    Id = x.Id,
                    AdresboekId = x.AdresboekId,
                    Organisatie = new OrganisatieViewModel
                    {
                        Id = x.Adresboek.Organisatie.Id,
                        VerwijzerInAdresboek = x.Adresboek.Organisatie.VerwijzerInAdresboek,
                    },
                    Status = x.Status,
                    Shared = x.Shared,
                    Geslacht = x.Persoon.Geslacht,
                    Geboortedatum = x.Persoon.Geboortedatum ?? default,
                    VolledigeNaam = x.Persoon.VolledigeNaam,
                    Achternaam = x.Persoon.Achternaam,
                    Bsn = x.Bsn,
                    Lengte = x.Lengte,
                    AgbCodeVerwijzer = x.AgbCodeVerwijzer,
                    NaamVerwijzer = x.NaamVerwijzer,
                    Verwijsdatum = x.Verwijsdatum,
                    VerzekeraarNaam = x.Zorgverzekering.Verzekeraar.Naam,
                    Uzovi = x.Zorgverzekering.Verzekeraar.Uzovi.ToString(),
                    VerzekerdeNummer = x.Zorgverzekering.VerzekerdeNummer,
                    PatientNummer = x.Zorgverzekering.PatientNummer,
                    ProfielCode = x.Zorgprofiel?.ProfielCode ?? ProfielCode.Geen,
                    ProfielStartdatum = x.Zorgprofiel?.ProfielStartdatum ?? default,
                    ProfielEinddatum = x.Zorgprofiel?.ProfielEinddatum ?? default,
                    Adres = x.Adres != null ?
                        new AdresViewModel
                        {
                            Id = x.Adres.Id,
                            Straat = x.Adres?.Straat,
                            Huisnummer = x.Adres?.Huisnummer,
                            HuisnummerToevoeging = x.Adres?.Huisnummertoevoeging,
                            Postcode = x.Adres?.Postcode,
                            Woonplaats = x.Adres?.Woonplaats,
                            LandNaam = x.Adres?.LandNaam,
                            LandId = x.Adres?.LandId,
                            WoonachtigOp = x.Adres?.WoonachtigOp ?? default,
                            WoonachtigTot = x.Adres?.WoonachtigTot ?? default,
                            Land = x.Adres?.Land != null ?
                                new LandViewModel
                                {
                                    Id = x.Adres.Land.Id,
                                    NativeName = x.Adres.Land.NativeName
                                }
                                : null
                        }
                        : new AdresViewModel(),
                    AangemaaktDoorId = x.AangemaaktDoorId,
                    AangemaaktOp = x.AangemaaktOp,
                    AangemaaktDoor = x.AangemaaktDoor,
                    CollegaIds = x.Users.Select(y => y.UserId).ToList(),
                    Zorgprofielen = x.Zorgprofielen
                })
                .OrderBy(i => i.Achternaam);
        }

        return model;
    }
}