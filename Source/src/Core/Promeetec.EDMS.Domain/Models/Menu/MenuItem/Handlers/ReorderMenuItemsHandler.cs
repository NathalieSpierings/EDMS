using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Menu.Menu;
using Promeetec.EDMS.Domain.Models.Menu.MenuItem.Commands;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Menu.MenuItem.Handlers
{
    public class ReorderMenuItemsHandler : ICommandHandler<ReorderMenuItems>
    {
        private readonly IMenuRepository _repository;

        public ReorderMenuItemsHandler(IMenuRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IEvent>> Handle(ReorderMenuItems command)
        {
            var menu = await _repository.Query().Include(i => i.MenuItems).FirstOrDefaultAsync(x => x.Id == command.Id && x.Status != Status.Verwijderd);
            if (menu == null)
                throw new DataException($"Menu met Id {command.Id} niet gevonden.");


            menu.ReorderMenuItems(command);
            await _repository.UpdateAsync(menu);

            return new IEvent[] { };
        }
    }
}
