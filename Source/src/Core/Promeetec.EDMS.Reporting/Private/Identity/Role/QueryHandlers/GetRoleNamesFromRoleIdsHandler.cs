using System.Collections.Generic;
using System.Linq;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Identity.Role.Queries;

namespace Promeetec.EDMS.Reporting.Private.Identity.Role.QueryHandlers;

public class GetRoleNamesFromRoleIdsHandler : IQueryHandler<GetRoleNamesFromRoleIds, IEnumerable<string>>
{
    private readonly IRoleRepository _repository;

    public GetRoleNamesFromRoleIdsHandler(IRoleRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<string> Handle(GetRoleNamesFromRoleIds query)
    {
        var result = new List<string>();
        var dbEntities = _repository.Query()
            .Where(x => query.RoleIds.Contains(x.Id))
            .Select(x => x.Name).OrderBy(o => o);

        result.AddRange(dbEntities);
        return result;
    }
}