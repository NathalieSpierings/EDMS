using System;
using System.Linq;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Mvc.Components.Slidepanel;
using Promeetec.EDMS.Reporting.Private.ContextMenu;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

public class MedewerkersViewModel : ModelBase
{
    public string SearchTerm { get; set; }
    public Guid? OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public IQueryable<MedewerkerListItemViewModel> Medewerkers { get; set; }


    //protected override void CreateGridContextMenuItems(GridContextMenuViewModel gridContextMenu)
    //{
    //    gridContextMenu.Add(new GridContextMenu
    //    {
    //        ClientName = "cmOverzicht",
    //        Icon = "pm_icon_dashboard",
    //        Title = "Overzicht",
    //        Type = GridContextMenuItemType.Link,
    //        Url = UrlAction("Index", "Home", new { Area = "" }),
    //        Roles = new[] { RoleNames.RaadplegenMedewerkers }
    //    });

    //    gridContextMenu.Add(new GridContextMenu
    //    {
    //        ClientName = "cmDetails",
    //        Icon = "pm_icon_preview",
    //        Title = "Details",
    //        Type = GridContextMenuItemType.LoadInTabbedSlidepanel,
    //        Url = UrlAction("Details", "Medewerker", new { Area = "" }),
    //        Roles = new[] { RoleNames.RaadplegenMedewerkers }
    //    });

    //    base.CreateGridContextMenuItems(gridContextMenu);
    //}


    //protected override void CreateSlidepanelTabs(SlidepanelTabsViewModel slidepanel)
    //{
    //    slidepanel.Add(new SlidepanelTab
    //    {
    //        ClientName = "tabDetails",
    //        TabPaneName = "paneDetails",
    //        Title = "Details",
    //        Icon = "pm_icon_circle_info",
    //        Active = true,
    //        LoadUrl = UrlAction("Details", "Medewerker", new { Area = "" })
    //    });

    //    slidepanel.Add(new SlidepanelTab
    //    {
    //        ClientName = "tabVektis",
    //        TabPaneName = "paneVektis",
    //        Title = "Vektis",
    //        Icon = "pm_icon_circle_info",
    //        TabPaneCssClass = "canvas",
    //        Active = false,
    //        LoadUrl = UrlAction("Vektis", "Medewerker", new { Area = "" })
    //    });

    //    if (User.IsInterneMedewerker)
    //    {
    //        slidepanel.Add(new SlidepanelTab
    //        {
    //            ClientName = "tabActiviteit",
    //            TabPaneName = "paneActiviteit",
    //            Title = "Activiteit",
    //            Icon = "pm_icon_circle_info",
    //            TabPaneCssClass = "canvas",
    //            Active = false,
    //            LoadUrl = UrlAction("Activiteit", "Medewerker", new { Area = "" })
    //        });
    //    }

    //    base.CreateSlidepanelTabs(slidepanel);
    //}
}