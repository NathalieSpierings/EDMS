using Promeetec.EDMS.Domain.Betrokkene.Notification.Commands;

namespace Promeetec.EDMS.Domain.Betrokkene.Notification.Handlers;

public class CreateProductHandlerAsync : ICommandHandlerAsync<CreateNotificatie>
{
    private readonly INotificatieRepository _repository;

    public CreateProductHandlerAsync(INotificatieRepository repository)
    {
        _repository = repository;
    }

    public async Task<CommandResponse> HandleAsync(CreateNotificatie command)
    {
        var notificatie = new Notificatie(command);
        await _repository.AddAsync(notificatie);

        return new CommandResponse
        {
            Events = notificatie.Events
        };
    }
}