using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Medewerker.Queries;
using Promeetec.EDMS.Reporting.Identity.Group.Queries;
using Promeetec.EDMS.Reporting.Private.Identity.Role.Models;
using Promeetec.EDMS.Reporting.Private.Identity.Role.Queries;

namespace Promeetec.EDMS.Reporting.Private.Identity.Role.QueryHandlers;

public class GetRoleHandler : IQueryHandlerAsync<GetRole, RoleViewModel>
{
    private readonly IDispatcher _dispatcher;
    private readonly IRoleRepository _repository;

    public GetRoleHandler(IDispatcher dispatcher, IRoleRepository repository)
    {
        _dispatcher = dispatcher;
        _repository = repository;
    }

    public async Task<RoleViewModel> HandleAsync(GetRole query)
    {
        var dbQuery = await _repository.GetByIdAsync(query.RoleId);
        var groupIds = dbQuery.Groups.Select(x => x.GroupId);
        var groupNames = _dispatcher.GetResult(new GetGroupNamesFromGroupIds { GroupIds = groupIds });

        var userIds = dbQuery.Users.Select(x => x.UserId).ToList();
        var medewerkerNames = await _dispatcher.GetResultAsync(new GetMedewerkerNamesFromIds { Ids = userIds });


        return new RoleViewModel
        {
            Id = dbQuery.Id,
            Name = dbQuery.Name,
            Description = dbQuery.Description,
            RoleType = dbQuery.RoleType,
            Status = dbQuery.Status,
            GroupNames = groupNames,
            MedewerkerNames = medewerkerNames,
            Groups = dbQuery.Groups.ToList(),
            AantalGebruikers = dbQuery.Users.Count,
            AantalGroepen = dbQuery.Groups.Count
        };
    }
}