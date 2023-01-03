using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Identity.Role.Models;
using Promeetec.EDMS.Reporting.Private.Identity.Role.Queries;

namespace Promeetec.EDMS.Reporting.Private.Identity.Role.QueryHandlers;

public class GetRolesHandler : IQueryHandlerAsync<GetRoles, RolesViewModel>
{
    private readonly IRoleRepository _repository;

    public GetRolesHandler(IRoleRepository repository)
    {
        _repository = repository;
    }

    public async Task<RolesViewModel> HandleAsync(GetRoles query)
    {
        var model = new RolesViewModel { Roles = new List<RoleListItemViewModel>() };
        var dbQuery = _repository.Query();

        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                dbQuery = dbQuery.Where(x => x.Name.Contains(match) ||
                                             x.Description.Contains(match) ||
                                             x.Status.ToString().Trim().Contains(match));
            }
        }

        var items = dbQuery.Select(x => new RoleListItemViewModel
        {
            Id = x.Id,
            Name = x.Name,
            Status = x.Status,
            Description = x.Description,
            RoleType = x.RoleType,
            AantalGroepen = x.Groups.Count,
            AantalGebruikers = x.Users.Count
        });

        model.Roles = await items.OrderBy(o => o.Name).ToListAsync();

        return model;
    }
}