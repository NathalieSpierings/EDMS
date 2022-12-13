using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Menu.Menu.Commands;
using Promeetec.EDMS.Domain.Models.Menu.Menu.Events;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Menu.Menu.Handlers;

public class DeleteMenuHandler : ICommandHandler<DeleteMenu>
{
    private readonly IMenuRepository _repository;
    private readonly IEventRepository _eventRepository;

    public DeleteMenuHandler(IMenuRepository repository, IEventRepository eventRepository)
    {
        _repository = repository;
        _eventRepository = eventRepository;
    }

    public async Task<IEnumerable<IEvent>> Handle(DeleteMenu command)
    {
        var menu = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
        if (menu == null)
            throw new DataException($"Menu met Id {command.Id} niet gevonden.");

        menu.Delete();

        var @event = new MenuVerwijderd
        {
            TargetId = menu.Id,
            TargetType = nameof(Menu),
            OrganisatieId = command.OrganisatieId,
            UserId = command.UserId,
            UserDisplayName = command.UserDisplayName,

            Status = Status.Verwijderd.ToString()
        };

        await _repository.UpdateAsync(menu);
        await _eventRepository.AddAsync(@event.ToDbEntity());

        return new IEvent[] { @event };
    }
}