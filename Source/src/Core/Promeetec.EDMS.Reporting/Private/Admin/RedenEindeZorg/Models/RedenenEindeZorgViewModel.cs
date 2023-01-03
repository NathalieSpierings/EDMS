using System.Collections.Generic;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Mvc.Components.Slidepanel;
using Promeetec.EDMS.Reporting.Private.ContextMenu;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.RedenEindeZorg.Models;

public class RedenenEindeZorgViewModel : ModelBase
{
    public IEnumerable<RedenEindeZorgViewModel> RedenenEindeZorg { get; set; }

    protected override void CreateGridContextMenuItems(GridContextMenuViewModel gridContextMenu)
    {
        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmDetails",
            Icon = "pm_icon_preview",
            Title = "Details",
            Type = GridContextMenuItemType.LoadInTabbedSlidepanel,
            Url = UrlAction("Details", "RedenEindeZorg", new { Area = "Admin" }),
            Roles = new[] { RoleNames.RaadplegenZorgstraten }
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
            LoadUrl = UrlAction("Details", "RedenEindeZorg", new { Area = "Admin" })
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
                LoadUrl = UrlAction("Activiteit", "RedenEindeZorg", new { Area = "Admin" })
            });
        }

        base.CreateSlidepanelTabs(slidepanel);
    }
}