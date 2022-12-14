using FluentValidation;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake.Events;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.Gli.Intake.Handlers;

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