using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Role.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Role.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Identity.Role.Handlers;

public class DeleteRoleHandler : ICommandHandler<DeleteRole>
{
    private readonly IRoleRepository _repository;
    private readonly IEventRepository _eventRepository;

    public DeleteRoleHandler(IRoleRepository repository, IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(DeleteRole command)
    {
        var Role = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
        if (Role == null)
            throw new DataException($"Rol met Id {command.Id} niet gevonden.");


        Role.Delete();

        var @event = new RolVerwijderd
        {
            TargetId = Role.Id,
            TargetType = nameof(Role),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Status = Status.Verwijderd.ToString()
        };

        await _repository.UpdateAsync(Role);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}