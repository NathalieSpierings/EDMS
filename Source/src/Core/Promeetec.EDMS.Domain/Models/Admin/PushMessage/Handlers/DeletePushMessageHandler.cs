using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Admin.PushMessage.Commands;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Admin.PushMessage.Handlers
{
    public class DeletePushMessageHandler : ICommandHandler<DeletePushMessage>
    {
        private readonly IPushMessageRepository _repository;

        public DeletePushMessageHandler(IPushMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IEvent>> Handle(DeletePushMessage command)
        {
            var message = await _repository.GetByIdAsync(command.PushMessageId);
            if (message == null)
                throw new ApplicationException($"Bericht niet gevonden. Id: {command.PushMessageId}");

            await _repository.RemoveAsync(message);

            return new IEvent[] { };
        }
    }
}