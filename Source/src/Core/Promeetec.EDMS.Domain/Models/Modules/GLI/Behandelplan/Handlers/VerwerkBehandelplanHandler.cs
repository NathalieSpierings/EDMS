using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Handlers;

public class VerwerkGliRegistratieHandler : ICommandHandler<ProcessBehandelplan>
{
    private readonly IGliBehandelplanRepository _repository;
    private readonly IEventRepository _eventRepository;

    public VerwerkGliRegistratieHandler(IGliBehandelplanRepository repository, IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(ProcessBehandelplan command)
    {
        var behandelplan = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Verwerkt == false);
        if (behandelplan == null)
            throw new DataException($"GLI behandelplan met Id {command.Id} niet gevonden.");

        behandelplan.Process(command);

        var @event = new BehandelplanVerwerkt
        {
            TargetId = behandelplan.Id,
            TargetType = nameof(GliBehandelplan),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Verwerkt = "Ja",
            VerwerktOp = command.VerwerktOp.ToString("dd-MM-yyyy"),
            Status = command.Status.ToString()
        };

        await _repository.UpdateAsync(behandelplan);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}