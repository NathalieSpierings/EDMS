using System.Data.Entity;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Adres.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Land.Models;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.QueryHandlers;

public class GetOrganisatieOverzichtHandler : IQueryHandlerAsync<GetOrganisatieOverzicht, OrganisatieOverzichtViewModel>
{
    private readonly IOrganisatieRepository _repository;

    public GetOrganisatieOverzichtHandler(IOrganisatieRepository repository)
    {
        _repository = repository;
    }

    public async Task<OrganisatieOverzichtViewModel> HandleAsync(GetOrganisatieOverzicht query)
    {
        var dbQuery = await _repository
            .Query()
            .AsNoTracking()
            .FirstOrDefaultAsync(y => y.Id == query.OrganisatieId);

        if (dbQuery == null)
        {
            return new OrganisatieOverzichtViewModel
            {
                Organisatie = new OrganisatieViewModel
                {
                    Id = query.OrganisatieId
                }
            };
        }


        var model = new OrganisatieOverzichtViewModel
        {
            Organisatie = new OrganisatieViewModel
            {
                Id = dbQuery.Id,
                Status = dbQuery.Status,
                Nummer = dbQuery.Nummer,
                Naam = dbQuery.Naam,
                AgbCodeOnderneming = dbQuery.AgbCodeOnderneming,
                Zorggroep = dbQuery.Zorggroep,
                Telefoon = dbQuery.TelefoonZakelijk,
                Telefoon1 = dbQuery.TelefoonPrive,
                Email = dbQuery.Email,
                Website = dbQuery.Website,
                Beperkt = dbQuery.Beperkt,
                BeperktReden = dbQuery.BeperktReden,
                ContactpersoonId = dbQuery.ContactpersoonId,
                ContactpersoonVolledigeNaam = dbQuery.Contactpersoon?.Persoon.VolledigeNaam,
                VoorraadId = dbQuery.Voorraad.Id,
                AdresboekId = dbQuery.Adresboek.Id,
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
            }
        };
        return model;
    }
}