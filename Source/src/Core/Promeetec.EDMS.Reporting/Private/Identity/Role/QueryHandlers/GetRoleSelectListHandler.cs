using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Identity.Role.Models;
using Promeetec.EDMS.Reporting.Private.Identity.Role.Queries;

namespace Promeetec.EDMS.Reporting.Private.Identity.Role.QueryHandlers;

/// <summary>
///     Checkbox list.
/// </summary>
public class GetRoleSelectListHandler : IQueryHandlerAsync<GetRoleSelectList, RoleSelectList>
{
    private readonly IRoleRepository _repository;

    public GetRoleSelectListHandler(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<RoleSelectList> HandleAsync(GetRoleSelectList query)
    {
        await Task.CompletedTask;

        var dbQuery = _repository.Query().Where(x => x.Status == Status.Actief);

        var model = new RoleSelectList
        {
            Roles = dbQuery.Select(x => new RoleSelectListItem
            {
                Id = x.Id,
                Name = x.Name,
                Selected = false
            }).OrderBy(x => x.Name).ToList()
        };
        return model;
    }
}