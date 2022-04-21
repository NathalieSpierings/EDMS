using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Menu;

public class Menu : AggregateRoot
{
    /// <summary>
    /// The name of the menu.
    /// </summary>
    [Required, MaxLength(200)]
    public string Name { get; set; }


    #region Navigation properties

    public virtual ICollection<MenuItem> MenuItems { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty menu.
    /// </summary>
    public Menu()
    {

    }
}