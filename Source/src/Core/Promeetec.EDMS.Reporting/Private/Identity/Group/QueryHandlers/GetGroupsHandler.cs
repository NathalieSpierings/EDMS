using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Identity.Group.Models;
using Promeetec.EDMS.Reporting.Private.Identity.Group.Queries;

namespace Promeetec.EDMS.Reporting.Private.Identity.Group.QueryHandlers;

public class GetGroupsHandler : IQueryHandlerAsync<GetGroups, GroupsViewModel>
{
    private readonly IGroupRepository _repository;

    public GetGroupsHandler(IGroupRepository repository)
    {
        _repository = repository;
    }

    public async Task<GroupsViewModel> HandleAsync(GetGroups query)
    {
        var model = new GroupsViewModel { Groups = new List<GroupListItemViewModel>() };

        var dbQuery = _repository.Query();

        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                dbQuery = dbQuery.Where(x => x.Name.Contains(match) || x.Description.Contains(match) || x.Status.ToString().Trim().Contains(match));
            }
        }

        var items = dbQuery.Select(x => new GroupListItemViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Description = x.Description,
            Status = x.Status,
            AantalRollen = x.Roles.Count,
            AantalGebruikers = x.Users.Count
        });

        model.Groups = await items.OrderBy(o => o.Name).ToListAsync();

        return model;
    }
}