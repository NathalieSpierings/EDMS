using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Admin.PushMessage.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Admin.PushMessage.Handlers;

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
        var message = new Admin.PushMessage.PushMessage(command);

        if (command.SelectedGroupIds.Any())
        {
            var groups = _groupRepository.GetGroups(command.SelectedGroupIds);
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