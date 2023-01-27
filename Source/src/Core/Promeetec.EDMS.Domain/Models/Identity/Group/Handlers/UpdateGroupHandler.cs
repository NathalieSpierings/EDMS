using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Group.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Group.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Identity.Group.Handlers;

public class UpdateGroupHandler : ICommandHandler<UpdateGroup>
{
    private readonly IGroupRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<UpdateGroup> _validator;

    public UpdateGroupHandler(IGroupRepository repository,
        IEventRepository eventRepository,
        IValidator<UpdateGroup> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(UpdateGroup command)
    {
        await _validator.ValidateCommand(command);

        var group = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
        if (group == null)
            throw new DataException($"Groep met Id {command.Id} niet gevonden.");

        group.Update(command);

        var @event = new GroepGewijzigd
        {
            TargetId = group.Id,
            TargetType = nameof(Group),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Naam = command.Name,
            Omschrijving = command.Description
        };

        await _repository.UpdateAsync(group);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}