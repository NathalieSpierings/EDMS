using System;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Promeetec.EDMS.Domain.Models.Betrokkene.PushMessage;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.QueryHandlers;

public class GetPushMessagesHandler : IQueryHandlerAsync<GetPushMessages, PushMessagesViewModel>
{
    private readonly IPushMessageRepository _repository;

    public GetPushMessagesHandler(IPushMessageRepository repository)
    {
        _repository = repository;
    }

    public async Task<PushMessagesViewModel> HandleAsync(GetPushMessages query)
    {
        var dbQuery = _repository.Query().AsNoTracking();


        // Zoeken
        if (!string.IsNullOrWhiteSpace(query.SearchTerm))
        {
            var matchWoorden = query.SearchTerm.ToLower().Split(' ');
            foreach (var match in matchWoorden)
            {
                if (DateTime.TryParse(match, out var datum))
                {
                    dbQuery = dbQuery.Where(x => DbFunctions.TruncateTime(x.Date) == datum);
                }
                else
                {
                    dbQuery = dbQuery.Where(x => x.Title.Contains(match) ||
                                                 x.Message.Contains(match));
                }
            }
        }

        var items = dbQuery.Select(x => new PushMessageListItemViewModel
        {
            Id = x.Id,
            Title = x.Title,
            Message = x.Message,
            Date = x.Date,
            Status = x.Status
        });

        var model = new PushMessagesViewModel
        {
            Messages = await items.OrderByDescending(o => o.Date).ToListAsync()
        };

        return model;
    }
}