using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Menu;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Menu.Models;
using Promeetec.EDMS.Reporting.Private.Menu.Queries;

namespace Promeetec.EDMS.Reporting.Private.Menu.QueryHandlers;

public class GetAdminMenusHandler : IQueryHandlerAsync<GetAdminMenus, AdminMenusViewModel>
{
    private readonly IMenuRepository _repository;

    public GetAdminMenusHandler(IMenuRepository repository)
    {
        _repository = repository;
    }

    public async Task<AdminMenusViewModel> HandleAsync(GetAdminMenus query)
    {
        await Task.CompletedTask;

        var dbQuery = _repository.Query()
            .AsNoTracking();

        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                dbQuery = dbQuery.Where(x => x.Status.ToString().Trim().Contains(match)
                                             || x.MenuType.ToString().Trim().Contains(match)
                                             || x.Name.Contains(match));
            }
        }

        var model = new AdminMenusViewModel
        {
            Menus = dbQuery.Select(x => new AdminMenuListItemViewModel
            {
                Id = x.Id,
                Name = x.Name,
                MenuType = x.MenuType,
                Status = x.Status
            }).OrderBy(o => o.Name)
        };

        return model;
    }
}