using System.Data.Entity;
using System.Linq;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Betrokkene.PushMessage;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Queries;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.QueryHandlers;

public class GetUserPushMessageHandler : IQueryHandler<GetUserPushMessage, UserPushMessageViewModel>
{
    private readonly IMedewerkerRepository _medewerkerRepository;
    public GetUserPushMessageHandler(IMedewerkerRepository medewerkerRepository)
    {
        _medewerkerRepository = medewerkerRepository;
    }

    public UserPushMessageViewModel Handle(GetUserPushMessage query)
    {
        var model = new UserPushMessageViewModel();

        var user = _medewerkerRepository
            .Query()
            .AsNoTracking()
            .Include(i => i.PushMessages)
            .FirstOrDefault(x => x.Id == query.UserId);

        if (user.PushMessages != null && user.PushMessages.Any())
        {
            var lastMessage = user.PushMessages
                .OrderByDescending(x => x.Message.Date)
                .FirstOrDefault(x => x.Message.Status == PushMessageStatus.Gepubliceerd && x.Read == false);

            if (lastMessage != null)
            {
                model.Id = lastMessage.MessageId;
                model.MedewerkerId = query.UserId;
                model.Date = lastMessage.Message.Date;
                model.Title = lastMessage.Message.Title;
                model.Message = lastMessage.Message.Message;
                model.Status = lastMessage.Message.Status;
            }
        }

        return model;
    }
}