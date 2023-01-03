using System;
using System.Collections.Generic;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Mvc.Components.Slidepanel;
using Promeetec.EDMS.Reporting.Private.ContextMenu;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Models;

public class GliRegistratiesViewModel : ModelBase
{
    public Guid OrganisatieId { get; set; }
    public IEnumerable<GliRegistratieListItemViewModel> GliRegistraties { get; set; } = new List<GliRegistratieListItemViewModel>();

    protected override void CreateGridContextMenuItems(GridContextMenuViewModel gridContextMenu)
    {
        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmDetails",
            Icon = "pm_icon_preview",
            Title = "Details",
            Type = GridContextMenuItemType.LoadInTabbedSlidepanel,
            Url = UrlAction("Details", "GliRegistratie", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenGliRegistraties, RoleNames.RaadplegenEigenGliRegistraties }
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
            LoadUrl = UrlAction("Details", "GliRegistratie", new { Area = "" })
        });

        base.CreateSlidepanelTabs(slidepanel);
    }
}