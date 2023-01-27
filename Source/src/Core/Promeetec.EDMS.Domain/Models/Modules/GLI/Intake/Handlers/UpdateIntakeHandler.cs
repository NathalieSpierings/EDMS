using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Handlers;

public class UpdateIntakeHandler : ICommandHandler<UpdateIntake>
{
    private readonly IGliIntakeRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<UpdateIntake> _validator;

    public UpdateIntakeHandler(IGliIntakeRepository repository, IEventRepository eventRepository, IValidator<UpdateIntake> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(UpdateIntake command)
    {
        await _validator.ValidateCommand(command);

        var intake = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Verwerkt == false);
        if (intake == null)
            throw new DataException($"GLI intake met Id {command.Id} niet gevonden.");

        var @event = new IntakeGewijzigd
        {
            TargetId = intake.Id,
            TargetType = nameof(GliIntake),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            IntakeDatum = command.IntakeDatum.ToString("dd-MM-yyyy"),
            Opmerking = command.Opmerking,
            Lengte = command.WeegMoment?.Lengte.ToString(),
            Gewicht = command.WeegMoment?.Gewicht.ToString(),
            Opnamedatum = command.WeegMoment is { Opnamedatum: { } }
                ? command.WeegMoment.Opnamedatum.ToString("dd-MM-yyyy")
                : string.Empty
        };

        intake.UpdateIntake(command);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}