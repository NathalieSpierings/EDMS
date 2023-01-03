using System;
using System.Collections.Generic;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Mvc.Components.Slidepanel;
using Promeetec.EDMS.Reporting.Private.ContextMenu;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Haarwerk.Models;

public class HaarwerkenViewModel : ModelBase
{
    public string SearchTerm { get; set; }
    public bool Processed { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public IEnumerable<HaarwerkListItemViewModel> Prestaties { get; set; } = new List<HaarwerkListItemViewModel>();

    protected override void CreateGridContextMenuItems(GridContextMenuViewModel gridContextMenu)
    {
        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmDetails",
            Icon = "pm_icon_preview",
            Title = "Details",
            Type = GridContextMenuItemType.LoadInTabbedSlidepanel,
            Url = UrlAction("Details", "Haarwerk", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenHaarwerken }
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
            LoadUrl = UrlAction("Details", "Haarwerk", new { Area = "" })
        });

        base.CreateSlidepanelTabs(slidepanel);
    }
}