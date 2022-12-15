using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Events;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;
using Promeetec.EDMS.Extensions;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Handlers;

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