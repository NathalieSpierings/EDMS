using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Changelog;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Changelog.Models;
using Promeetec.EDMS.Reporting.Private.Changelog.Queries;

namespace Promeetec.EDMS.Reporting.Private.Changelog.QueryHandlers;

public class GetChangelogHandler : IQueryHandlerAsync<GetChangelog, ChangelogViewModel>
{
    private readonly IChangelogRepository _repository;

    public GetChangelogHandler(IChangelogRepository repository)
    {
        _repository = repository;
    }

    public async Task<ChangelogViewModel> HandleAsync(GetChangelog query)
    {
        var dbQuery = _repository.Query().AsNoTracking();

        var model = new ChangelogViewModel
        {
            Posts = await dbQuery.Select(x => new ChangelogPostViewModel
            {
                Id = x.Id,
                Date = x.Date,
                Title = x.Title,
                Description = x.Description,
                Content = x.Content,
                Type = x.Type,
                Tag = x.Tag
            }).OrderByDescending(o => o.Date).ToListAsync()
        };

        return model;
    }
}