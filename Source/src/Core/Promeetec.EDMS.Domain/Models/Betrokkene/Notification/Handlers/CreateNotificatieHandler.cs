using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Notification.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Notification.Handlers;

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