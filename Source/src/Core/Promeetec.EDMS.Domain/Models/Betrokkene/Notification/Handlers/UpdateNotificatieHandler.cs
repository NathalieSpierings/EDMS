using Promeetec.EDMS.Domain.Betrokkene.Notification.Commands;

namespace Promeetec.EDMS.Domain.Betrokkene.Notification.Handlers;

public class UpdateNotificatieHandler : ICommandHandlerAsync<UpdateNotificatie>
{
    private readonly INotificatieRepository _repository;

    public UpdateNotificatieHandler(INotificatieRepository repository)
    {
        _repository = repository;
    }

    public async Task<CommandResponse> HandleAsync(UpdateNotificatie command)
    {
        var notificatie = await _repository.GetByIdAsync(command.AggregateRootId);
        if (notificatie == null)
            throw new ApplicationException($"Notificatie niet gevonden. Id: {command.AggregateRootId}");

        notificatie.Update(command);
        await _repository.UpdateAsync(notificatie);

        return new CommandResponse
        {
            Events = notificatie.Events
        };
    }
}