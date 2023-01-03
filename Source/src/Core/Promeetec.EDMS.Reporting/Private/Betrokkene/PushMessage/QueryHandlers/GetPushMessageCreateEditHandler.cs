using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.PushMessage;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.QueryHandlers;

public class GetPushMessageCreateEditHandler : IQueryHandlerAsync<GetPushMessageCreateEdit, PushMessageCreateViewModel>
{
    private readonly IPushMessageRepository _repository;

    public GetPushMessageCreateEditHandler(IPushMessageRepository repository)
    {
        _repository = repository;
    }

    public async Task<PushMessageCreateViewModel> HandleAsync(GetPushMessageCreateEdit query)
    {
        var model = await _repository.Query()
           .Where(x => x.Id == query.PushMessageId)
           .Select(x => new PushMessageCreateViewModel
           {
               Id = x.Id,
               Date = x.Date,
               Title = x.Title,
               Message = x.Message,
               Users = x.Users
           }).FirstOrDefaultAsync();

        return model;
    }
}