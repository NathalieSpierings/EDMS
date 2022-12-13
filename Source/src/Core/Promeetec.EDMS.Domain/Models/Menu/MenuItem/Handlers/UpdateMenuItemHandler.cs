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
using Promeetec.EDMS.Extensions;

namespace Promeetec.EDMS.Domain.Models.Menu.MenuItem.Handlers
{
    public class UpdateMenuItemHandler : ICommandHandler<UpdateMenuItem>
    {
        private readonly IMenuRepository _repository;
        private readonly IEventRepository _eventRepository;

        public UpdateMenuItemHandler(IMenuRepository repository, IEventRepository eventRepository)
        {
            _repository = repository;
            _eventRepository = eventRepository;
        }

        public async Task<IEnumerable<IEvent>> Handle(UpdateMenuItem command)
        {
            var menu = await _repository.Query().Include(i => i.MenuItems).FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
            if (menu == null)
                throw new DataException($"Menu met Id {command.Id} niet gevonden.");

            menu.UpdateMenuItem(command);

            var @event = new MenuItemGewijzigd
            {
                TargetId = menu.Id,
                TargetType = nameof(Menu),
                OrganisatieId = command.OrganisatieId,
                UserId = command.UserId,
                UserDisplayName = command.UserDisplayName,

                ClientName = command.ClientName,
                Key = command.Key,
                Title = command.Title,
                Tooltip = command.Tooltip,
                Icon = command.Icon,
                ActionName = command.ActionName,
                ControllerName = command.ControllerName,
                RouteVariables = command.RouteVariables,
                Url = command.Url,
                Disabled = command.Disabled ? "Ja" : "Nee",
                Status = Status.Verwijderd.ToString(),
                Soort = command.MenuItemType.GetDisplayName()
            };

            await _repository.UpdateAsync(menu);
            await _eventRepository.AddAsync(@event.ToDbEntity());

            return new IEvent[] { @event };
        }
    }
}
