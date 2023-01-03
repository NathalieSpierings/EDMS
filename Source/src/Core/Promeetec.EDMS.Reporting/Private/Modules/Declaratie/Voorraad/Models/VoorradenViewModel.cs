using System.Collections.Generic;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Reporting.Private.ContextMenu;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Voorraad.Models;

public class VoorradenViewModel : ModelBase
{
    public IEnumerable<VoorraadListItemViewModel> Voorraden { get; set; }

    protected override void CreateGridContextMenuItems(GridContextMenuViewModel gridContextMenu)
    {
        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmVoorraad",
            Icon = "pm_icon_voorraad",
            Title = "Voorraad",
            Type = GridContextMenuItemType.Link,
            Url = UrlAction("Voorraad", "Organisatie", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenVoorraad }
        });

        base.CreateGridContextMenuItems(gridContextMenu);
    }
}