using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Handlers;

public class DeleteAanleveringHandler : ICommandHandler<DeleteAanlevering>
{
    private readonly IAanleveringRepository _repository;
    private readonly IEventRepository _eventRepository;

    public DeleteAanleveringHandler(IAanleveringRepository repository, IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(DeleteAanlevering command)
    {
        var aanlevering = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
        if (aanlevering == null)
            throw new DataException($"Aanlevering met Id {command.Id} niet gevonden.");

        aanlevering.Delete(command);

        var @event = new AanleveringVerwijderd
        {
            TargetId = aanlevering.Id,
            TargetType = nameof(Aanlevering),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Status = Status.Verwijderd.ToString()
        };

        await _repository.UpdateAsync(aanlevering);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}