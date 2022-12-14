using FluentValidation;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Events;
using Promeetec.EDMS.Events;
using Promeetec.EDMS.Extensions;

namespace Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Handlers;

public class StartBehandeltrajectHandler : ICommandHandler<StartBehandeltraject>
{
    private readonly IGliBehandelplanRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<StartBehandeltraject> _validator;

    public StartBehandeltrajectHandler(IGliBehandelplanRepository repository, IEventRepository eventRepository, IValidator<StartBehandeltraject> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(StartBehandeltraject command)
    {
        await _validator.ValidateCommand(command);

        var behandelplan = new GliBehandelplan(command);

        var @event = new BehandeltrajectGestart
        {
            TargetId = behandelplan.Id,
            TargetType = nameof(GliBehandelplan),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Startdatum = command.Startdatum.ToString("dd-MM-yyyy"),
            Einddatum = command.Einddatum.ToString("dd-MM-yyyy"),
            GliProgramma = command.Programma.ToString(),
            Fase = command.Fase.GetDisplayName(),
            Opmerking = command.Opmerking
        };

        await _repository.AddAsync(behandelplan);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };

    }
}