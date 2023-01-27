using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Notification.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Notification.Handlers;

public class UpdateNotificatieHandler : ICommandHandler<UpdateNotificatie>
{
    private readonly INotificatieRepository _repository;

    public UpdateNotificatieHandler(INotificatieRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<IEvent>> Handle(UpdateNotificatie command)
    {
        var noti = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
        if (noti == null)
            throw new DataException($"Notificatie met Id {command.Id} niet gevonden.");

        noti.Update(command);
        await _repository.UpdateAsync(noti);

        return new IEvent[] { };
    }
}