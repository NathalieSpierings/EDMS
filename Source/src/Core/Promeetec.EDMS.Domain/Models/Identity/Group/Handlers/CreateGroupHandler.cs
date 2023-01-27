using FluentValidation;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Group.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Group.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Identity.Group.Handlers;

public class CreateGroupHandler : ICommandHandler<CreateGroup>
{
    private readonly IGroupRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<CreateGroup> _validator;

    public CreateGroupHandler(IGroupRepository repository,
        IEventRepository eventRepository,
        IValidator<CreateGroup> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateGroup command)
    {
        await _validator.ValidateCommand(command);

        var group = new Group(command);

        var @event = new GroepAangemaakt
        {
            TargetId = group.Id,
            TargetType = nameof(Group),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Status = Status.Actief.ToString(),
            Naam = command.Name,
            Omschrijving = command.Description
        };

        await _repository.AddAsync(group);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}