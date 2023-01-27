using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Core.Extensions;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Handlers;

public class UpdateAanleveringHandler : ICommandHandler<UpdateAanlevering>
{
    private readonly IAanleveringRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<UpdateAanlevering> _validator;

    public UpdateAanleveringHandler(IAanleveringRepository repository, IEventRepository eventRepository, IValidator<UpdateAanlevering> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(UpdateAanlevering command)
    {
        await _validator.ValidateCommand(command);

        var aanlevering = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
        if (aanlevering == null)
            throw new DataException($"Land met Id {command.Id} niet gevonden.");

        aanlevering.Update(command);

        var @event = new AanleveringGewijzigd
        {
            TargetId = aanlevering.Id,
            TargetType = nameof(Aanlevering),
            OrganisatieId = command.OrganisatieId,
            OrganisatieDisplayName = command.OrganisatieDisplayName,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,
            
            ReferentiePromeetec = command.ReferentiePromeetec,
            AanleverStatus = command.AanleverStatus.GetDisplayName(),
            ToevoegenBestand = command.ToevoegenBestand.ToString(),
            Opmerking = command.Opmerking,

            Behandelaar = command.Behandelaar,
            Eigenaar = command.Eigenaar,
            BehandelaarId = command.BehandelaarId,
            EigenaarId = command.EigenaarId
        };

        await _repository.UpdateAsync(aanlevering);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}