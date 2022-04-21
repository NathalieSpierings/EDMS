using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Models.Menu;

public class MenuItem : AggregateRoot
{
    /// <summary>
    /// The menu item title.
    /// </summary>
    [Required, MaxLength(200)]
    public string Titel { get; set; }

    /// <summary>
    /// The menu item tooltip.
    /// </summary>
    [MaxLength(200)]
    public string Tooltip { get; set; }

    /// <summary>
    /// The menu item icon.
    /// </summary>
    [MaxLength(128)]
    public string GlyphIcon { get; set; }

    /// <summary>
    /// The menu item sort order.
    /// </summary>
    [Required]
    public int Volgorde { get; set; }

    /// <summary>
    /// The menu item action name.
    /// </summary>
    [MaxLength(450)]
    public string Action { get; set; }

    /// <summary>
    /// The menu item controller name.
    /// </summary>
    [MaxLength(450)]
    public string Controller { get; set; }

    /// <summary>
    /// The menu item module name.
    /// </summary>
    public string ModuleNaam { get; set; }

    /// <summary>
    /// The menu item url.
    /// </summary>
    [Required, MaxLength(450)]
    public string Url { get; set; }

    /// <summary>
    /// The menu item status.
    /// </summary>
    public Status Status { get; set; }


    #region Navigation properties

    public Guid MenuId { get; set; }
    public virtual Menu Menu { get; set; }
    
    public Guid? ParentId { get; set; }
    public virtual MenuItem Parent { get; set; }

    public virtual ICollection<MenuItemRole> Roles { get; set; } = new List<MenuItemRole>();

    #endregion


    /// <summary>
    /// Creates an empty menu item.
    /// </summary>
    public MenuItem()
    {

    }
}