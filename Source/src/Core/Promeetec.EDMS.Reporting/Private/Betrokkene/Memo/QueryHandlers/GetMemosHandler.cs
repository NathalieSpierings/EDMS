using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.Memo;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Memo.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Memo.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Memo.QueryHandlers;

public class GetMemosHandler : IQueryHandlerAsync<GetMemos, MemosViewModel>
{
    private readonly IMemoRepository _repository;

    public GetMemosHandler(IMemoRepository repository)
    {
        _repository = repository;
    }

    public async Task<MemosViewModel> HandleAsync(GetMemos query)
    {
        await Task.CompletedTask;
        var dbQuery = _repository.Query()
            .AsNoTracking()
            .Where(x => x.MedewerkerId == query.MedewerkerId)
            .OrderByDescending(o => o.Date)
            .Select(x => new MemoViewModel
            {
                Id = x.Id,
                Date = x.Date,
                Content = x.Content
            });

        var model = new MemosViewModel
        {
            OrganisatieId = query.OrganisatieId,
            MedewerkerId = query.MedewerkerId,
            Memos = dbQuery
        };

        return model;
    }
}