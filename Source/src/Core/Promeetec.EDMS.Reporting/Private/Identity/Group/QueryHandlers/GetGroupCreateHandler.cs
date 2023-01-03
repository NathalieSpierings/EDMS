using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Identity.Group.Models;
using Promeetec.EDMS.Reporting.Private.Identity.Group.Queries;

namespace Promeetec.EDMS.Reporting.Private.Identity.Group.QueryHandlers;

public class GetGroupCreateHandler : IQueryHandlerAsync<GetGroupCreate, GroupCreateViewModel>
{
    private readonly IGroupRepository _repository;

    public GetGroupCreateHandler(IGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<GroupCreateViewModel> HandleAsync(GetGroupCreate query)
    {
        await Task.CompletedTask;

        var dbQuery = _repository
            .Query()
            .FirstOrDefault(x => x.Id == query.GroupId);

        if (dbQuery == null)
            return new GroupCreateViewModel();


        return new GroupCreateViewModel
        {
            Id = dbQuery.Id,
            Name = dbQuery.Name,
            Description = dbQuery.Description,
            Status = dbQuery.Status,
            Roles = new List<GroupRole>(dbQuery.Roles),
            Users = new List<GroupUser>(dbQuery.Users)
        };
    }
}