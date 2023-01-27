using System.Data;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.PushMessage.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.PushMessage.Handlers
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
                throw new DataException($"Bericht niet gevonden. Id: {command.PushMessageId}");

            await _repository.RemoveAsync(message);

            return new IEvent[] { };
        }
    }
}