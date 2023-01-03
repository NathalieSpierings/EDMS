using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Identity.Role.Models;
using Promeetec.EDMS.Reporting.Private.Identity.Role.Queries;

namespace Promeetec.EDMS.Reporting.Private.Identity.Role.QueryHandlers;

public class GetRoleCreateHandler : IQueryHandlerAsync<GetRoleCreate, RoleCreateViewModel>
{
    private readonly IRoleRepository _repository;

    public GetRoleCreateHandler(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<RoleCreateViewModel> HandleAsync(GetRoleCreate query)
    {
        var role = await _repository.GetByIdAsync(query.RoleId);

        return new RoleCreateViewModel
        {
            Id = role.Id,
            Name = role.Name,
            Description = role.Description,
            RoleType = role.RoleType
        };
    }
}