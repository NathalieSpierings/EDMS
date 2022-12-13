using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Extensions;
using Promeetec.EDMS.Domain.Models.Event;
using Promeetec.EDMS.Domain.Models.Menu.Menu;
using Promeetec.EDMS.Domain.Models.Menu.MenuItem.Commands;
using Promeetec.EDMS.Domain.Models.Menu.MenuItem.Events;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Menu.MenuItem.Handlers
{
    public class RemoveMenuItemHandler : ICommandHandler<RemoveMenuItem>
    {
        private readonly IMenuRepository _repository;
        private readonly IEventRepository _eventRepository;

        public RemoveMenuItemHandler(IMenuRepository repository, IEventRepository eventRepository)
        {
            _repository = repository;
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<IEvent>> Handle(RemoveMenuItem command)
        {
            var menu = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
            if (menu == null)
                throw new DataException($"Menu met Id {command.Id} niet gevonden.");

            menu.RemoveMenuItem(command);

            var @event = new MenuItemVerwijderd
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
}
