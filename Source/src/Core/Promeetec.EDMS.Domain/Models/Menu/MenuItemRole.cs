using Promeetec.EDMS.Domain.Models.Identity.Role;

namespace Promeetec.EDMS.Domain.Models.Menu;

public class MenuItemRole
{
    #region Navigation properties
    
    public Guid MenuItemId { get; set; }
    public MenuItem MenuItem { get; set; }

    public Guid RoleId { get; set; }
    public Role Role { get; set; }

    #endregion
}