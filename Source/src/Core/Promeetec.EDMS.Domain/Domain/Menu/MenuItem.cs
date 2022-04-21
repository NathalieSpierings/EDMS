using OpenCqrs.Domain;
using Promeetec.EDMS.Domain.Domain.Shared;
using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Domain.Menu;

public class MenuItem : AggregateRoot
{
    [StringLength(200)]
    public string Titel { get; set; }


    [StringLength(200)]
    public string Tooltip { get; set; }


    [StringLength(128)]
    public string GlyphIcon { get; set; }


    [Required]
    public int Volgorde { get; set; }


    [StringLength(450)]
    public string Action { get; set; }

    [StringLength(450)]
    public string Controller { get; set; }

    public string ModuleNaam { get; set; }


    [StringLength(450)]
    public string Url { get; set; }


    [Required]
    public Status Status { get; set; }

    public Guid MenuId { get; set; }
    public virtual Menu Menu { get; set; }

    public Guid? ParentId { get; set; }
    public virtual MenuItem Parent { get; set; }

    public virtual IList<MenuItemRole> Roles { get; set; } = new List<MenuItemRole>();



    public MenuItem()
    {
    }
}