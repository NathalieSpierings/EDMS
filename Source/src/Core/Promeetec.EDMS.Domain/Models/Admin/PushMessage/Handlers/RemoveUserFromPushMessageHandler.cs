using System.Data;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Admin.PushMessage.Commands;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Admin.PushMessage.Handlers
{
    public class RemoveUserFromPushMessageHandler : ICommandHandler<RemoveUserFromPushMessage>
    {
        private readonly IPushMessageRepository _repository;

        public RemoveUserFromPushMessageHandler(IPushMessageRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IEvent>> Handle(RemoveUserFromPushMessage command)
        {
            var message = await _repository.GetPushmessageByIdAsync(command.PushMessageId);
            if (message == null)
                throw new DataException($"Bericht niet gevonden. Id: {command.PushMessageId}");

            if (message.Users.Any())
            {
                var totalUsers = message.Users.Count;
                if (totalUsers > 1)
                {
                    var user = message.Users.FirstOrDefault(x => x.UserId == command.MedewerkerId);
                    message.Users.Remove(user);
                    await _repository.UpdateAsync(message);
                }
                else
                {
                    // This is the last user so remove message
                    await _repository.RemoveAsync(message);
                }
            }

            return new IEvent[] { };
        }
    }
}