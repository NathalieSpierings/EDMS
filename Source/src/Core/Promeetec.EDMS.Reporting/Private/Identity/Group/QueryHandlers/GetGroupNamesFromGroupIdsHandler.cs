using System.Collections.Generic;
using System.Linq;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Identity.Group.Queries;

namespace Promeetec.EDMS.Reporting.Private.Identity.Group.QueryHandlers;

public class GetGroupNamesFromGroupIdsHandler : IQueryHandler<GetGroupNamesFromGroupIds, IEnumerable<string>>
{
    private readonly IGroupRepository _repository;

    public GetGroupNamesFromGroupIdsHandler(IGroupRepository repository)
    {
        _repository = repository;
    }

    public IEnumerable<string> Handle(GetGroupNamesFromGroupIds query)
    {
        var result = new List<string>();
        var dbEntities = _repository.Query()
            .Where(x => query.GroupIds.Contains(x.Id))
            .Select(x => x.Name);

        result.AddRange(dbEntities);
        return result;
    }
}