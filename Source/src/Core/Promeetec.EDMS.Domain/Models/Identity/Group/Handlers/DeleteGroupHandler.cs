using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Betrokkene.Land.Events;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Identity.Group.Commands;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Identity.Group.Handlers;

public class DeleteGroupHandler : ICommandHandler<DeleteGroup>
{
    private readonly IGroupRepository _repository;
    private readonly IEventRepository _eventRepository;

    public DeleteGroupHandler(IGroupRepository repository, IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(DeleteGroup command)
    {
        var group = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
        if (group == null)
            throw new DataException($"Groep met Id {command.Id} niet gevonden.");


        group.Delete();

        var @event = new LandVerwijderd
        {
            TargetId = group.Id,
            TargetType = nameof(Group),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Status = Status.Verwijderd.ToString()
        };

        await _repository.UpdateAsync(group);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}