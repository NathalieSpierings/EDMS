using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Notification.Commands;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Notification.Handlers;

public class CreateNotificatieHandler : ICommandHandler<CreateNotificatie>
{
    private readonly INotificatieRepository _repository;

    public CreateNotificatieHandler(INotificatieRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateNotificatie command)
    {
        var notificatie = new Notificatie(command);
        await _repository.AddAsync(notificatie);

        return new IEvent[] { };
    }
}