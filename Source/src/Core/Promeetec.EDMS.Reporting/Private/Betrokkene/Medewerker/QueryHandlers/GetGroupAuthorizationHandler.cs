using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.QueryHandlers;

public class GetGroupAuthorizationHandler : IQueryHandlerAsync<GetGroupAuthorization, GroupAuthorizationViewModel>
{
    private readonly IMedewerkerRepository _repository;

    public GetGroupAuthorizationHandler(IMedewerkerRepository repository)
    {
        _repository = repository;
    }

    public async Task<GroupAuthorizationViewModel> HandleAsync(GetGroupAuthorization query)
    {
        var dbQuery = _repository.Query();

        var medewerker = await dbQuery.FirstOrDefaultAsync(x => x.Id == query.MedewerkerId);
        if (medewerker == null)
            return new GroupAuthorizationViewModel();


        return new GroupAuthorizationViewModel
        {
            Id = medewerker.Id,
            OrganisatieId = medewerker.OrganisatieId,
            OrganisatieNaam = medewerker.Organisatie.Naam,
            VolledigeNaam = medewerker.Persoon.VolledigeNaam,
            UserName = medewerker.UserName,
            Email = medewerker.Persoon.Email,
            Roles = new List<UserRole>(medewerker.Roles),
            Groups = new List<GroupUser>(medewerker.Groups)
        };
    }
}