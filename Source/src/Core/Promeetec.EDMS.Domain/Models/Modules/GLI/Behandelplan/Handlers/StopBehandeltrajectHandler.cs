using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Events;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Handlers;

public class StopBehandeltrajectHandler : ICommandHandler<StopBehandeltraject>
{
    private readonly IGliBehandelplanRepository _repository;
    private readonly IEventRepository _eventRepository;

    public StopBehandeltrajectHandler(IGliBehandelplanRepository repository, IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(StopBehandeltraject command)
    {
        var behandelplan = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
        if (behandelplan == null)
            throw new DataException($"GLI behandelplan met Id {command.Id} niet gevonden.");

        behandelplan.StopBehandeltraject(command);

        var @event = new BehandeltrajectGestopt
        {
            TargetId = behandelplan.Id,
            TargetType = nameof(GliBehandelplan),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            VoortijdigGestopt = "Ja",
            VoortijdigeStopdatum = command.VoortijdigeStopdatum.ToString("dd-MM-yyyy"),
            VoortijdigeStopCode = command.VoortijdigeStopCode,
            VoortijdigeStopReden = command.VoortijdigeStopReden,
            Opmerking = command.Opmerking
        };

        await _repository.UpdateAsync(behandelplan);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}