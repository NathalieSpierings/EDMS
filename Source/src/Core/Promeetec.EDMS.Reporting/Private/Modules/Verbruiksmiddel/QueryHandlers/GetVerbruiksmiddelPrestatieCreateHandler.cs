using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel;
using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Adres.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Land.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Verzekerde.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Models;
using Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.QueryHandlers;

public class GetVerbruiksmiddelPrestatieCreateHandler : IQueryHandlerAsync<GetVerbruiksmiddelPrestatieCreate, VerbruiksmiddelPrestatieCreateViewModel>
{
    private readonly IVerbruiksmiddelPrestatieRepository _repository;

    public GetVerbruiksmiddelPrestatieCreateHandler(IVerbruiksmiddelPrestatieRepository repository)
    {
        _repository = repository;
    }


    public async Task<VerbruiksmiddelPrestatieCreateViewModel> HandleAsync(GetVerbruiksmiddelPrestatieCreate query)
    {
        var dbQuery = await _repository.Query()
            .Include(i => i.Verzekerde)
            .Where(x => x.Id == query.VerbruiksmiddelPrestatieId && x.OrganisatieId == query.OrganisatieId)
            .FirstOrDefaultAsync();

        var model = new VerbruiksmiddelPrestatieCreateViewModel
        {
            Id = dbQuery.Id,
            OrganisatieId = dbQuery.OrganisatieId,
            AgbCodeOnderneming = dbQuery.AgbCodeOnderneming,
            HulpmiddelenSoort = dbQuery.HulpmiddelenSoort,
            Status = dbQuery.Status,
            VerzekerdeId = dbQuery.VerzekerdeId,
            Hulpmiddel = new VerbruiksmiddelHulpmiddelCreateViewModel
            {
                ZIndex = dbQuery.ZIndex,
                PrestatieDatum = dbQuery.PrestatieDatum,
                Hoeveelheid = dbQuery.Hoeveelheid
            },
            Verzekerde = new VerzekerdeViewModel
            {
                Id = dbQuery.VerzekerdeId,
                AdresboekId = dbQuery.Verzekerde.AdresboekId,
                Organisatie = new OrganisatieViewModel
                {
                    Id = dbQuery.Verzekerde.Adresboek.Organisatie.Id,
                    VerwijzerInAdresboek = dbQuery.Verzekerde.Adresboek.Organisatie.VerwijzerInAdresboek,
                },
                Status = dbQuery.Verzekerde.Status,
                Shared = dbQuery.Verzekerde.Shared,
                Geslacht = dbQuery.Verzekerde.Persoon.Geslacht,
                Geboortedatum = dbQuery.Verzekerde.Persoon.Geboortedatum ?? default,
                FormeleNaam = dbQuery.Verzekerde.Persoon.FormeleNaam,
                VolledigeNaam = dbQuery.Verzekerde.Persoon.VolledigeNaam,
                Achternaam = dbQuery.Verzekerde.Persoon.Achternaam,
                Bsn = dbQuery.Verzekerde.Bsn,
                Lengte = dbQuery.Verzekerde.Lengte,
                AgbCodeVerwijzer = dbQuery.Verzekerde.AgbCodeVerwijzer,
                NaamVerwijzer = dbQuery.Verzekerde.NaamVerwijzer,
                Verwijsdatum = dbQuery.Verzekerde.Verwijsdatum,
                VerzekeraarNaam = dbQuery.Verzekerde.Zorgverzekering.Verzekeraar.Naam,
                Uzovi = dbQuery.Verzekerde.Zorgverzekering.Verzekeraar.Uzovi.ToString(),
                VerzekerdeNummer = dbQuery.Verzekerde.Zorgverzekering.VerzekerdeNummer,
                PatientNummer = dbQuery.Verzekerde.Zorgverzekering.PatientNummer,
                ProfielCode = dbQuery.Verzekerde.Zorgprofiel?.ProfielCode ?? ProfielCode.Geen,
                ProfielStartdatum = dbQuery.Verzekerde.Zorgprofiel?.ProfielStartdatum ?? default,
                ProfielEinddatum = dbQuery.Verzekerde.Zorgprofiel?.ProfielEinddatum ?? default,
                Adres = dbQuery.Verzekerde.Adres != null ?
                new AdresViewModel
                {
                    Id = dbQuery.Verzekerde.Adres.Id,
                    Straat = dbQuery.Verzekerde.Adres?.Straat,
                    Huisnummer = dbQuery.Verzekerde.Adres?.Huisnummer,
                    HuisnummerToevoeging = dbQuery.Verzekerde.Adres?.Huisnummertoevoeging,
                    Postcode = dbQuery.Verzekerde.Adres?.Postcode,
                    Woonplaats = dbQuery.Verzekerde.Adres?.Woonplaats,
                    LandNaam = dbQuery.Verzekerde.Adres?.LandNaam,
                    LandId = dbQuery.Verzekerde.Adres?.LandId,
                    WoonachtigOp = dbQuery.Verzekerde.Adres?.WoonachtigOp ?? default,
                    WoonachtigTot = dbQuery.Verzekerde.Adres?.WoonachtigTot ?? default,
                    Land = dbQuery.Verzekerde.Adres?.Land != null ?
                        new LandViewModel
                        {
                            Id = dbQuery.Verzekerde.Adres.Land.Id,
                            NativeName = dbQuery.Verzekerde.Adres.Land.NativeName
                        }
                        : null
                }
                : new AdresViewModel(),
                AangemaaktDoorId = dbQuery.Verzekerde.AangemaaktDoorId,
                AangemaaktOp = dbQuery.Verzekerde.AangemaaktOp,
                AangemaaktDoor = dbQuery.Verzekerde.AangemaaktDoor,
                Zorgprofielen = dbQuery.Verzekerde.Zorgprofielen,
                CollegaIds = dbQuery.Verzekerde.Users.Select(y => y.UserId).ToList(),
            }
        };

        return model;
    }
}