using System;
using System.Collections.Generic;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Mvc.Components.Slidepanel;
using Promeetec.EDMS.Reporting.Private.ContextMenu;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanleverbericht.Models;

public class AanleverberichtenViewModel : ModelBase
{
    public string SearchTerm { get; set; }
    public bool GlobalSearch { get; set; }
    public Guid? BerichtId { get; set; }
    public int AantalAanleverberichten { get; set; }
    public AanleveringViewModel Aanlevering { get; set; } = new();
    public IEnumerable<AanleverberichtListItemViewModel> Aanleverberichten { get; set; } = new List<AanleverberichtListItemViewModel>();


    protected override void CreateGridContextMenuItems(GridContextMenuViewModel gridContextMenu)
    {
        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmDetails",
            Icon = "pm_icon_preview",
            Title = "Details",
            Type = GridContextMenuItemType.LoadInTabbedSlidepanel,
            Url = UrlAction("Details", "Aanleverbericht", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenAanleverberichten }
        });
    }

    protected override void CreateSlidepanelTabs(SlidepanelTabsViewModel slidepanelTabs)
    {
        slidepanelTabs.Add(new SlidepanelTab
        {
            ClientName = "tabDetails",
            TabPaneName = "paneDetails",
            Title = "Details",
            Icon = "pm_icon_circle_info",
            Active = true,
            LoadUrl = UrlAction("Details", "Aanleverbericht", new { Area = "" })
        });

    }
}