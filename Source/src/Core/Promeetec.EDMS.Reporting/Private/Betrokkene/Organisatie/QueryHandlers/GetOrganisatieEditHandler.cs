using System.Data.Entity;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Adres.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Land.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.QueryHandlers;

public class GetOrganisatieEditHandler : IQueryHandlerAsync<GetOrganisatieEdit, OrganisatieEditViewModel>
{
    private readonly IOrganisatieRepository _repository;

    public GetOrganisatieEditHandler(IOrganisatieRepository repository)
    {
        _repository = repository;
    }

    public async Task<OrganisatieEditViewModel> HandleAsync(GetOrganisatieEdit query)
    {
        var dbQuery = await _repository
            .Query()
            .AsNoTracking()
            .FirstOrDefaultAsync(y => y.Id == query.OrganisatieId);

        var model = new OrganisatieEditViewModel
        {
            Id = dbQuery.Id,
            Nummer = dbQuery.Nummer,
            Naam = dbQuery.Naam,
            AgbCodeOnderneming = dbQuery.AgbCodeOnderneming,
            Zorggroep = dbQuery.Zorggroep,
            Telefoon = dbQuery.TelefoonZakelijk,
            Telefoon1 = dbQuery.TelefoonPrive,
            Email = dbQuery.Email,
            Website = dbQuery.Website,
            AanleverbestandLocatie = dbQuery.AanleverbestandLocatie,
            AanleverStatusNaSchrijvenAanleverbestanden = dbQuery.AanleverStatusNaSchrijvenAanleverbestanden,
            ContactpersoonId = dbQuery.ContactpersoonId,
            IONZoekoptie = dbQuery.IONZoekoptie,
            ZorggroepRelatieId = dbQuery.ZorggroepRelatieId,
            COVControleProcessType = dbQuery.COVControleProcessType,
            COVControleType = dbQuery.COVControleType,
            VerwijzerInAdresboek = dbQuery.VerwijzerInAdresboek,
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
                    Land = dbQuery.Adres?.Land != null ?
                        new LandViewModel
                        {
                            Id = dbQuery.Adres.Land.Id,
                            NativeName = dbQuery.Adres.Land.NativeName
                        }
                        : null
                }
                : new AdresViewModel()
        };
        return model;
    }
}