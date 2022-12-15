using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Admin.PushMessage.Commands;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Admin.PushMessage.Handlers;

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
            throw new ApplicationException($"Bericht niet gevonden. Id: {command.PushMessageId}");

        message.Publish();
        await _repository.UpdateAsync(message);

        return new IEvent[] { };
    }
}