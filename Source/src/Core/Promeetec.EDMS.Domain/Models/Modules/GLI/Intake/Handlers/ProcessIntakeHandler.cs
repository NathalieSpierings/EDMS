using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Handlers;

public class ProcessIntakeHandler : ICommandHandler<ProcessIntake>
{
    private readonly IGliIntakeRepository _repository;
    private readonly IEventRepository _eventRepository;

    public ProcessIntakeHandler(IGliIntakeRepository repository, IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(ProcessIntake command)
    {
        var intake = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Verwerkt == false);
        if (intake == null)
            throw new DataException($"GLI intake met Id {command.Id} niet gevonden.");

        intake.Process(command);
        
        var @event = new IntakeVerwerkt
        {
            TargetId = intake.Id,
            TargetType = nameof(GliIntake),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Verwerkt = "Ja",
            VerwerktOp = command.VerwerktOp.ToString("dd-MM-yyyy")
        };

        await _repository.UpdateAsync(intake);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };

    }
}