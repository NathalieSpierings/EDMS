using System;
using System.Collections.Generic;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Mvc.Components.Slidepanel;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.ContextMenu;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Aanlevering.Models;

public class AanleveringenViewModel : ModelBase
{
    public string SearchTerm { get; set; }
    public bool GlobalSearch { get; set; }
    public Guid? DetailId { get; set; }
    public OrganisatieViewModel Organisatie { get; set; } = new();
    public IEnumerable<AanleveringListItemViewModel> Aanleveringen { get; set; } = new List<AanleveringListItemViewModel>();


    protected override void CreateGridContextMenuItems(GridContextMenuViewModel gridContextMenu)
    {
        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmDetails",
            Icon = "pm_icon_preview",
            Title = "Details",
            Type = GridContextMenuItemType.LoadInTabbedSlidepanel,
            Url = UrlAction("Details", "Aanlevering", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenAanleveringen }
        });

        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmBerichten",
            Icon = "pm_icon_messages",
            Title = "Berichten",
            Type = GridContextMenuItemType.Link,
            Url = UrlAction("Aanleverberichten", "Aanlevering", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenAanleverberichten }
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
            LoadUrl = UrlAction("Details", "Aanlevering", new { Area = "" })
        });

        if (!User.IsBlocked && User.IsInRole(RoleNames.RaadplegenOverigebestanden))
        {
            slidepanel.Add(new SlidepanelTab
            {
                ClientName = "tabAanleveringOverigebestanden",
                TabPaneName = "paneAanleveringOverigebestanden",
                Title = "Terugkoppeling",
                Icon = "pm_icon_circle_info",
                Active = false,
                LoadUrl = UrlAction("AanleveringOverigebestanden", "Aanlevering", new { Area = "" })
            });
        }

        if (!User.IsBlocked && (User.IsInRole(RoleNames.RaadplegenAanleverbestanden) || User.IsInRole(RoleNames.RaadplegenEigenAanleverbestanden)))
        {
            slidepanel.Add(new SlidepanelTab
            {
                ClientName = "tabAanleveringAanleverbestanden",
                TabPaneName = "paneAanleveringAanleverbestanden",
                Title = "Aanleverbestanden",
                Icon = "pm_icon_circle_info",
                Active = false,
                LoadUrl = UrlAction("AanleveringAanleverbestanden", "Aanlevering", new { Area = "" })
            });
        }

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
                LoadUrl = UrlAction("Activiteit", "Aanlevering", new { Area = "" })
            });
        }

        base.CreateSlidepanelTabs(slidepanel);
    }
}