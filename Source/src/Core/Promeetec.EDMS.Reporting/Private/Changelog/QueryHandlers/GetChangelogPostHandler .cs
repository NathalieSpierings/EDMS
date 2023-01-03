using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Changelog;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Changelog.Models;
using Promeetec.EDMS.Reporting.Private.Changelog.Queries;

namespace Promeetec.EDMS.Reporting.Private.Changelog.QueryHandlers;

public class GetChangelogPostHandler : IQueryHandlerAsync<GetChangelogPost, ChangelogPostViewModel>
{
    private readonly IChangelogRepository _repository;

    public GetChangelogPostHandler(IChangelogRepository repository)
    {
        _repository = repository;
    }

    public async Task<ChangelogPostViewModel> HandleAsync(GetChangelogPost query)
    {
        var model = await _repository
            .Query()
            .AsNoTracking()
            .Where(x => x.Id == query.PostId)
            .Select(x => new ChangelogPostViewModel
            {
                Id = x.Id,
                Date = x.Date,
                Title = x.Title,
                Description = x.Description,
                Content = x.Content,
                Type = x.Type,
                Tag = x.Tag,
            }).FirstOrDefaultAsync();

        return model;
    }
}