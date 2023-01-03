using System.Collections.Generic;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Mvc.Components.Slidepanel;
using Promeetec.EDMS.Reporting.Private.ContextMenu;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Identity.Group.Models;

public class GroupsViewModel : ModelBase
{
    public IList<GroupListItemViewModel> Groups { get; set; } = new List<GroupListItemViewModel>();

    protected override void CreateGridContextMenuItems(GridContextMenuViewModel gridContextMenu)
    {
        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmDetails",
            Icon = "pm_icon_preview",
            Title = "Details",
            Type = GridContextMenuItemType.LoadInTabbedSlidepanel,
            Url = UrlAction("Details", "Group", new { Area = "Admin" }),
            Roles = new[] { RoleNames.RaadplegenGroepen }
        });

        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmRollen",
            Icon = "pm_icon_user_lock",
            Title = "Rollen",
            Type = GridContextMenuItemType.Link,
            Url = UrlAction("GroupRoles", "Group", new { Area = "Admin" }),
            Roles = new[] { RoleNames.RaadplegenRollen }
        });

        base.CreateGridContextMenuItems(gridContextMenu);
    }

    protected override void CreateSlidepanelTabs(SlidepanelTabsViewModel slidepanel)
    {
        slidepanel.Add(new SlidepanelTab
        {
            ClientName = "tabDetails",
            TabPaneName = "paneDetails",
            Title = "Details",
            Icon = "pm_icon_circle_info",
            Active = true,
            LoadUrl = UrlAction("Details", "Group", new { Area = "Admin" })
        });

        if (User.IsInterneMedewerker)
        {
            slidepanel.Add(new SlidepanelTab
            {
                ClientName = "tabActiviteit",
                TabPaneName = "paneActiviteit",
                Title = "Activiteit",
                Icon = "pm_icon_circle_info",
                TabPaneCssClass = "canvas",
                Active = false,
                LoadUrl = UrlAction("Activiteit", "Group", new { Area = "Admin" })
            });
        }

        base.CreateSlidepanelTabs(slidepanel);
    }
}