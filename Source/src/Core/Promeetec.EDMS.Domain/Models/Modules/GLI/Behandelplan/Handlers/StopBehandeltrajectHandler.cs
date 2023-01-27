using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Handlers;

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