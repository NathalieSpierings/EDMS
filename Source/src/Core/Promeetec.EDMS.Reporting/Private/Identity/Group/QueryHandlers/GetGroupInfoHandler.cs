using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Betrokkene.Medewerker.Queries;
using Promeetec.EDMS.Reporting.Identity.Role.Queries;
using Promeetec.EDMS.Reporting.Private.Identity.Group.Models;
using Promeetec.EDMS.Reporting.Private.Identity.Group.Queries;

namespace Promeetec.EDMS.Reporting.Private.Identity.Group.QueryHandlers;

public class GetGroupHandler : IQueryHandlerAsync<GetGroup, GroupViewModel>
{
    private readonly IDispatcher _dispatcher;
    private readonly IGroupRepository _repository;

    public GetGroupHandler(IDispatcher dispatcher, IGroupRepository repository)
    {
        _dispatcher = dispatcher;
        _repository = repository;
    }

    public async Task<GroupViewModel> HandleAsync(GetGroup query)
    {
        var dbQuery = _repository
            .Query()
            .FirstOrDefault(x => x.Id == query.GroupId);

        if (dbQuery == null)
            return new GroupViewModel();

        var roleIds = dbQuery.Roles.Select(x => x.RoleId);
        var roleNames = _dispatcher.GetResult(new GetRoleNamesFromRoleIds { RoleIds = roleIds });

        var userIds = dbQuery.Users.Select(x => x.UserId).ToList();
        var medewerkerNames = await _dispatcher.GetResultAsync(new GetMedewerkerNamesFromIds { Ids = userIds });

        return new GroupViewModel
        {
            Id = dbQuery.Id,
            Name = dbQuery.Name,
            Description = dbQuery.Description,
            Status = dbQuery.Status,
            AantalRollen = dbQuery.Roles.Count,
            AantalGebruikers = dbQuery.Users.Count,
            RoleNames = roleNames,
            MedewerkerNames = medewerkerNames
        };
    }
}