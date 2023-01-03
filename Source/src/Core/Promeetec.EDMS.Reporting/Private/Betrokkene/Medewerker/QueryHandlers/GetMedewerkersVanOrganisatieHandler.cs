using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Betrokkene.User.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.QueryHandlers;

public class GetMedewerkersVanOrganisatieHandler : IQueryHandlerAsync<GetMedewerkersVanOrganisatie, List<MedewerkerViewModel>>
{
    private readonly IMedewerkerRepository _repository;

    public GetMedewerkersVanOrganisatieHandler(IMedewerkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<MedewerkerViewModel>> HandleAsync(GetMedewerkersVanOrganisatie query)
    {
        await Task.CompletedTask;

        var dbQuery = _repository.Query()
            .AsNoTracking()
            .Where(x => x.OrganisatieId == query.OrganisatieId && x.Status != Status.Verwijderd);

        if (query.Level2Only)
        {
            dbQuery = dbQuery.Where(x => x.UserProfile.EmailBijRapportage).OrderBy(o => o.Persoon.VolledigeNaam);
        }

        var medewerkers = dbQuery.Select(x => new MedewerkerViewModel
        {
            Id = x.Id,
            Organisatie = new OrganisatieViewModel
            {
                Id = x.OrganisatieId
            },
            Geslacht = x.Persoon.Geslacht,
            Voorletters = x.Persoon.Voorletters,
            Voornaam = x.Persoon.Voornaam,
            Tussenvoegsel = x.Persoon.Tussenvoegsel,
            Achternaam = x.Persoon.Achternaam,
            FormeleNaam = x.Persoon.FormeleNaam,
            VolledigeNaam = x.Persoon.VolledigeNaam,
            Doorkiesnummer = x.Persoon.Doorkiesnummer,
            Telefoon = x.Persoon.Telefoon,
            Telefoon1 = x.Persoon.Telefoon1,
            Email = x.Persoon.Email,
            UserProfile = new UserProfileViewModel
            {
                EmailBijRapportage = x.UserProfile.EmailBijRapportage
            }
        }).ToList();

        return medewerkers;
    }
}