using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Portaal.Core.Domain;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.MenuItem.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu;

public class Menu : AggregateRoot
{
    [Required, MaxLength(200)]
    public string Name { get; set; }

    public MenuType MenuType { get; set; }

    public Status Status { get; set; }


    #region Navigation properties

    public IList<MenuItem.MenuItem> MenuItems { get; set; } = new List<MenuItem.MenuItem>();

    #endregion


    /// <summary>
    /// Creates an empty menu.
    /// </summary>
    public Menu() { }
    public Menu(Guid id) : base(id) { }


    /// <summary>
    /// Creates a menu.
    /// </summary>
    /// <param name="cmd">The create menu command.</param>
    public Menu(CreateMenu cmd) : base(cmd.Id)
    {
        Status = Status.Actief;
        MenuType = cmd.MenuType;
        Name = cmd.Name;
    }

    /// <summary>
    /// Update the details of the menu.
    /// </summary>
    /// <param name="cmd">The update command.</param>
    public void Update(UpdateMenu cmd)
    {
        MenuType = cmd.MenuType;
        Name = cmd.Name;
    }


    /// <summary>
    /// Sets the status of the Menu as suspended.
    /// </summary>
    public void Suspend()
    {
        Status = Status.Inactief;
    }

    /// <summary>
    ///  Reinstates the Menu if suspended.
    /// </summary>
    public void Reinstate()
    {
        Status = Status.Actief;
    }


    /// <summary>
    /// Sets the status of the Menu as deleted.
    /// </summary>
    /// <param name="cmd">The delete command.</param>
    public void Delete()
    {
        if (Name.ToLowerInvariant() == "promeetec")
            throw new Exception("Promeetec menu kan niet verwijderd worden.");

        if (Name.ToLowerInvariant() == "external")
            throw new Exception("External menu kan niet verwijderd worden.");

        Status = Status.Verwijderd;
    }



    public void AddMenuItem(AddMenuItem cmd)
    {
        if (MenuItems.FirstOrDefault(x => x.Id == cmd.Id) != null)
            throw new Exception("Menu item is al toegevoegd");

        var sortOrder = MenuItems.Count(x => x.ParentId == Guid.Empty) + 1;
        MenuItems.Add(new MenuItem.MenuItem(cmd, sortOrder));
    }

    public void UpdateMenuItem(UpdateMenuItem cmd)
    {
        var menuItem = MenuItems.FirstOrDefault(x => x.Id == cmd.Id);

        if (menuItem == null || menuItem.Status == Status.Verwijderd)
            throw new Exception("Menu item niet gevonden");

        menuItem.Update(cmd);
    }


    public void ReorderMenuItems(ReorderMenuItems cmd)
    {
        var menuItems = cmd.MenuItems.Where(x => x.Id != null);

        var listSortedItems = new List<ReorderMenuItems.MenuItem>();
        var groupsByParent = menuItems.GroupBy(x => x.ParentId).ToList();

        foreach (var group in groupsByParent)
        {
            var parentId = group.Key;

            if (parentId != Guid.Empty && MenuItems.FirstOrDefault(x => x.Id == parentId) == null)
                throw new Exception("Parent menu item niet gevonden.");

            var items = group.ToList();

            for (int i = 0; i < items.Count; i++)
            {
                var id = items[i].Id;
                var sortOrder = i + 1;

                var menuItem = MenuItems.FirstOrDefault(x => x.Id == id);

                if (menuItem == null || menuItem.Status == Status.Verwijderd)
                    throw new Exception("Menu item niet gevonden.");

                if (menuItem.ParentId == parentId && menuItem.SortOrder == sortOrder)
                    continue;

                menuItem.Reorder(parentId, sortOrder);

                listSortedItems.Add(new ReorderMenuItems.MenuItem
                {
                    Id = id,
                    ParentId = parentId
                });
            }
        }
    }

    public void RemoveMenuItem(RemoveMenuItem cmd)
    {
        var menuItemToRemove = MenuItems.FirstOrDefault(x => x.Id == cmd.MenuItemId);

        if (menuItemToRemove == null || menuItemToRemove.Status == Status.Verwijderd)
            throw new Exception("Menu item om te verwijderen niet gevonden.");

        MarkMenuItemAsDeleted(menuItemToRemove);
    }

    private void MarkMenuItemAsDeleted(MenuItem.MenuItem? menuItem)
    {
        menuItem.Delete();

        var subMenuItemsToDelete = MenuItems
            .Where(x => x.ParentId == menuItem.Id && x.Status == Status.Actief)
            .ToList();

        foreach (var subMenuItem in subMenuItemsToDelete)
        {
            MarkMenuItemAsDeleted(subMenuItem);
        }
    }
}