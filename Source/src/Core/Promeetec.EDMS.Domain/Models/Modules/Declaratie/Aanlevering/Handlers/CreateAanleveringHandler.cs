using FluentValidation;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Handlers;

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
            OrganisatieDisplayName = command.OrganisatieDisplayName,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Status = Status.Actief.ToString(),
           
            Jaar = DateTime.Now.Year.ToString(),
            Aanleverdatum = DateTime.Now.ToString("dd-MM-yyyy"),
           
            Referentie = command.Referentie,
            ReferentiePromeetec = command.ReferentiePromeetec,
            AanleverStatus = AanleverStatus.Aangemaakt.ToString(),
            ToevoegenBestand = command.ToevoegenBestand ? "Ja" : "Nee",
            Opmerking = command.Opmerking,
            Behandelaar = command.Behandelaar,
            Eigenaar = command.Eigenaar,
            BehandelaarId = command.BehandelaarId,
            EigenaarId = command.EigenaarId
        };

        await _repository.AddAsync(aanlevering);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}