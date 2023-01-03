using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Changelog;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Changelog.Models;
using Promeetec.EDMS.Reporting.Private.Changelog.Queries;

namespace Promeetec.EDMS.Reporting.Private.Changelog.QueryHandlers;

public class GetChangelogPostCreateEditHandler : IQueryHandlerAsync<GetChangelogPostCreateEdit, ChangelogPostCreateEditViewModel>
{
    private readonly IChangelogRepository _repository;

    public GetChangelogPostCreateEditHandler(IChangelogRepository repository)
    {
        _repository = repository;
    }

    public async Task<ChangelogPostCreateEditViewModel> HandleAsync(GetChangelogPostCreateEdit query)
    {
        var model = await _repository.Query()
           .Where(x => x.Id == query.PostId)
           .Select(x => new ChangelogPostCreateEditViewModel
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