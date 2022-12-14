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

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Handlers;

public class ChangeEigenaarAanleveringHandler : ICommandHandler<ChangeEigenaarAanlevering>
{
    private readonly IAanleveringRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<ChangeEigenaarAanlevering> _validator;

    public ChangeEigenaarAanleveringHandler(IAanleveringRepository repository, IEventRepository eventRepository, IValidator<ChangeEigenaarAanlevering> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(ChangeEigenaarAanlevering command)
    {
        await _validator.ValidateCommand(command);

        var aanlevering = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
        if (aanlevering == null)
            throw new DataException($"Aanlevering met Id {command.Id} niet gevonden.");


        aanlevering.WijzigEigenaar(command);

        var @event = new EigenaarAanleveringGewijzigd
        {
            TargetId = aanlevering.Id,
            TargetType = nameof(Aanlevering),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Eigenaar = command.EigenaarVolledigeNaam,
            EigenaarId = command.EigenaarId

        };

        await _repository.UpdateAsync(aanlevering);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}