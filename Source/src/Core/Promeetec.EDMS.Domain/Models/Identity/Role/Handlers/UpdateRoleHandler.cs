using System.Data;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Role.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Role.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Identity.Role.Handlers;

public class UpdateRoleHandler : ICommandHandler<UpdateRole>
{
    private readonly IRoleRepository _repository;
    private readonly IEventRepository _eventRepository;
    private readonly IValidator<UpdateRole> _validator;

    public UpdateRoleHandler(IRoleRepository repository,
        IEventRepository eventRepository,
        IValidator<UpdateRole> validator)
    {
        _repository = repository;
        _eventRepository = eventRepository;
        _validator = validator;
    }

    public async Task<IEnumerable<IEvent>> Handle(UpdateRole command)
    {
        await _validator.ValidateCommand(command);

        var Role = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
        if (Role == null)
            throw new DataException($"Rol met Id {command.Id} niet gevonden.");

        Role.Update(command);

        var @event = new RolGewijzigd
        {
            TargetId = Role.Id,
            TargetType = nameof(Role),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Naam = command.Name,
            Omschrijving = command.Description
        };

        await _repository.UpdateAsync(Role);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}