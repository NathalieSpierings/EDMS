using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.PushMessage.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Group;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.PushMessage.Handlers;

public class CreatePushMessageHandler : ICommandHandler<CreatePushMessage>
{
    private readonly IPushMessageRepository _repository;
    private readonly IMedewerkerRepository _medewerkerRepository;
    private readonly IGroupRepository _groupRepository;

    public CreatePushMessageHandler(IPushMessageRepository repository, IMedewerkerRepository medewerkerRepository, IGroupRepository groupRepository)
    {
        _repository = repository;
        _medewerkerRepository = medewerkerRepository;
        _groupRepository = groupRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreatePushMessage command)
    {
        var message = new PushMessage(command);

        if (command.GroupIds.Any())
        {
            var groups = _groupRepository.GetGroups(command.GroupIds);
            if (groups.Any())
            {
                // Attach message only to users of the chosen groups

                var groupUsers = groups.SelectMany(x => x.Users);
                foreach (var user in groupUsers)
                {
                    message.Users.Add(new PushMessageToUser
                    {
                        UserId = user.User.Id,
                        MessageId = message.Id
                    });
                }

                await _repository.AddAsync(message);
            }
        }
        else
        {
            var users = _medewerkerRepository.Query();
            foreach (var user in users)
            {
                message.Users.Add(new PushMessageToUser
                {
                    UserId = user.Id,
                    MessageId = message.Id
                });
            }

            await _repository.AddAsync(message);
        }

        return new IEvent[] { };
    }
}