using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Identity.Group.Models;
using Promeetec.EDMS.Reporting.Private.Identity.Group.Queries;

namespace Promeetec.EDMS.Reporting.Private.Identity.Group.QueryHandlers;

/// <summary>
///     Checkbox list.
/// </summary>
public class GetGroupSelectListHandler : IQueryHandlerAsync<GetGroupSelectList, GroupSelectList>
{
    private readonly IGroupRepository _repository;

    public GetGroupSelectListHandler(IGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<GroupSelectList> HandleAsync(GetGroupSelectList query)
    {
        var dbQuery = _repository.Query()
            .AsNoTracking()
            .Where(x => x.Status == Status.Actief);

        if (query.User.IsInterneMedewerker && !query.User.IsInRole(RoleNames.Administrator))
        {
            dbQuery = dbQuery.Where(x => x.Name != GroupNames.Administrators &&
                                         x.Name != GroupNames.Beheerders &&
                                         x.Name != GroupNames.SecurityOfficer &&
                                         x.Name != GroupNames.DeclaratieBeheer &&
                                         x.Name != GroupNames.Declaratie);
        }

        var model = new GroupSelectList
        {
            Groups = await dbQuery.Select(x => new GroupSelectListItem
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Selected = false
            }).OrderBy(x => x.Name).ToListAsync()
        };
        return model;
    }
}