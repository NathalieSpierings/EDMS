using FluentValidation;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Role.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Role.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Identity.Role.Handlers;

public class CreateRoleHandler : ICommandHandler<CreateRole>
{
    private readonly IRoleRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<CreateRole> _validator;

    public CreateRoleHandler(IRoleRepository repository,
        IEventRepository eventRepository,
        IValidator<CreateRole> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(CreateRole command)
    {
        await _validator.ValidateCommand(command);

        var role = new Role(command);

        var @event = new RolAangemaakt
        {
            TargetId = role.Id,
            TargetType = nameof(Role),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Status = Status.Actief.ToString(),
            Naam = command.Name,
            Omschrijving = command.Description
        };

        await _repository.AddAsync(role);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}