using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Changelog.Commands;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Identity.Group.Commands;
using Promeetec.EDMS.Domain.Models.Identity.Group.Events;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Identity.Group.Handlers;

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