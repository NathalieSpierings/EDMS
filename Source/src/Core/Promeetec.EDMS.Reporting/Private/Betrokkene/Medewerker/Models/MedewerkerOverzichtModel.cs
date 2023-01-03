using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Mvc.Components.Slidepanel;
using Promeetec.EDMS.Reporting.Private.ContextMenu;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

public class MedewerkerOverzichtViewModel : ModelBase
{
    public MedewerkerViewModel Medewerker { get; set; }

    //protected override void CreateGridContextMenuItems(GridContextMenuViewModel gridContextMenu)
    //{
    //    gridContextMenu.Clear();

    //    gridContextMenu.Add(new GridContextMenu
    //    {
    //        ClientName = "cmDetails",
    //        Icon = "pm_icon_preview",
    //        Title = "Details",
    //        Active = true,
    //        Type = GridContextMenuItemType.LoadInTabbedSlidepanel,
    //        RouteValues = new { id = Medewerker.Id, organisatieId = Medewerker.Organisatie.Id },
    //        Url = UrlAction("Details", "Medewerker", new { Area = "", id = Medewerker.Id, organisatieId = Medewerker.Organisatie.Id }),
    //        Roles = new[] { RoleNames.RaadplegenEigenOverzicht, RoleNames.RaadplegenOverzichtMedewerker }
    //    });

    //    // Alleen zichtbaar voor interne medewerkers en eigenaar van de overzichtspagina.
    //    // (Rechten worden bepaald in _ContextMenu.cshtml)
    //    gridContextMenu.Add(new GridContextMenu
    //    {
    //        ClientName = "cmION",
    //        Icon = "pm_icon_healthcare_snake",
    //        Title = "ION Raadplegen",
    //        Active = true,
    //        Key = Medewerker.Id.ToString(),
    //        Url = UrlAction("Raadplegen", "ION", new { Area = "", medewerkerId = Medewerker.Id, organisatieId = Medewerker.Organisatie.Id }),
    //        RouteValues = new { medewerkerId = Medewerker.Id, organisatieId = Medewerker.Organisatie.Id },
    //        Type = GridContextMenuItemType.Link,
    //        Roles = new[] { RoleNames.RaadplegenION }
    //    });

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