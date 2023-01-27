using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Extensions;
using Promeetec.EDMS.Portaal.Domain.Models.Event;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Handlers;

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