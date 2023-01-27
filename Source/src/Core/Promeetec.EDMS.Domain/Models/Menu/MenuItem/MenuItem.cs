using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Portaal.Core.Domain;
using Promeetec.EDMS.Portaal.Domain.Models.Menu.MenuItem.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Shared;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.MenuItem;

public class MenuItem : AggregateRoot
{
    [MaxLength(200)]
    public string? ClientName { get; set; }

    public string? Key { get; set; }


    [Required, MaxLength(200)]
    public string Title { get; set; }


    [MaxLength(200)]
    public string? Tooltip { get; set; }


    [MaxLength(128)]
    public string? Icon { get; set; }


    [MaxLength(450)]
    public string? ActionName { get; set; }


    [MaxLength(450)]
    public string? ControllerName { get; set; }

    public string? RouteVariables { get; set; }

    [MaxLength(450)]
    public string? Url { get; set; }

    public int? SortOrder { get; set; }

    public MenuItemType MenuItemType { get; set; }

    public Status Status { get; set; }


    #region Navigation properties

    public Guid MenuId { get; set; }
    public virtual Menu.Menu Menu { get; set; }

    public Guid? ParentId { get; set; }
    public virtual MenuItem Parent { get; set; }

    public virtual IList<MenuItemRole> Roles { get; set; } = new List<MenuItemRole>();


    #endregion


    /// <summary>
    /// Creates an empty menu item.
    /// </summary>
    public MenuItem()
    {
    }


    /// <summary>
    /// Creates an menu item.
    /// </summary>
    /// <param name="cmd">The create menu item command.</param>
    /// <param name="sortOrder">The sort order.</param>
    public MenuItem(AddMenuItem cmd, int sortOrder) : base(cmd.Id)
    {
        MenuId = cmd.MenuId;
        ParentId = cmd.ParentId;
        ClientName = cmd.ClientName;
        Key = cmd.Key;
        Title = cmd.Title;
        Tooltip = cmd.Tooltip;
        Icon = cmd.Icon;
        ActionName = cmd.ActionName;
        ControllerName = cmd.ControllerName;
        RouteVariables = cmd.RouteVariables;
        Url = cmd.Url;
        SortOrder = sortOrder;
        MenuItemType = cmd.MenuItemType;
        Status = cmd.Status;

    }

    /// <summary>
    /// Update the details of the menu item.
    /// </summary>
    /// <param name="cmd">The update menu item command.</param>
    public void Update(UpdateMenuItem cmd)
    {
        ClientName = cmd.ClientName;
        Key = cmd.Key;
        Title = cmd.Title;
        Tooltip = cmd.Tooltip;
        Icon = cmd.Icon;
        ActionName = cmd.ActionName;
        ControllerName = cmd.ControllerName;
        RouteVariables = cmd.RouteVariables;
        Url = cmd.Url;
        MenuItemType = cmd.MenuItemType;
        Status = cmd.Status;
    }


    /// <summary>
    /// Reorders the menu.
    /// </summary>
    /// <param name="parentId">The unique parent identifier.</param>
    /// <param name="sortOrder">The sort order.</param>
    public void Reorder(Guid parentId, int sortOrder)
    {
        ParentId = parentId;
        SortOrder = sortOrder;
    }

    /// <summary>
    /// Set the status as deleted.
    /// </summary>
    public void Delete()
    {
        Status = Status.Verwijderd;
    }
}