using FluentValidation;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Handlers;

public class CreateIntakeHandler : ICommandHandler<CreateIntake>
{
    private readonly IGliIntakeRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<CreateIntake> _validator;

    public CreateIntakeHandler(IGliIntakeRepository repository, IEventRepository eventRepository, IValidator<CreateIntake> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateIntake command)
    {
        await _validator.ValidateCommand(command);

        var intake = new GliIntake(command);

        var @event = new IntakeAangemaakt
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

        await _repository.AddAsync(intake);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };

    }
}