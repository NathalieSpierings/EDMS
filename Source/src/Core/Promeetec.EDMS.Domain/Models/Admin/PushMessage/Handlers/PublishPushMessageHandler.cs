using System.Data;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.PushMessage.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.PushMessage.Handlers;

public class PublishPushMessageHandler : ICommandHandler<PublishPushMessage>
{
    private readonly IPushMessageRepository _repository;

    public PublishPushMessageHandler(IPushMessageRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<IEvent>> Handle(PublishPushMessage command)
    {
        var message = await _repository.GetByIdAsync(command.PushMessageId);
        if (message == null)
            throw new DataException($"Bericht niet gevonden. Id: {command.PushMessageId}");

        message.Publish();
        await _repository.UpdateAsync(message);

        return new IEvent[] { };
    }
}