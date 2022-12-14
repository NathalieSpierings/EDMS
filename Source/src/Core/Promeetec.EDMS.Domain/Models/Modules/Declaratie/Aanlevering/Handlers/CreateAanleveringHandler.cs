using FluentValidation;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Events;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Handlers;

public class CreateAanleveringHandler : ICommandHandler<CreateAanlevering>
{
    private readonly IAanleveringRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<CreateAanlevering> _validator;

    public CreateAanleveringHandler(IAanleveringRepository repository,
        IEventRepository eventRepository,
        IValidator<CreateAanlevering> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateAanlevering command)
    {
        await _validator.ValidateCommand(command);

        var aanlevering = new Aanlevering(command);

        var @event = new AanleveringAangemaakt
        {
            TargetId = aanlevering.Id,
            TargetType = nameof(Aanlevering),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Status = Status.Actief.ToString(),
            Organisatie = command.Organisatie,
            Behandelaar = command.Behandelaar,
            Eigenaar = command.Eigenaar,
            Jaar = DateTime.Now.Year.ToString(),
            Aanleverdatum = DateTime.Now.ToString("dd-MM-yyyy"),
            Referentie = command.Referentie,
            ReferentiePromeetec = command.ReferentiePromeetec,
            AanleverStatus = AanleverStatus.Aangemaakt.ToString(),
            ToevoegenBestand = command.ToevoegenBestand ? "Ja" : "Nee",
            Opmerking = command.Opmerking
        };

        await _repository.AddAsync(aanlevering);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}