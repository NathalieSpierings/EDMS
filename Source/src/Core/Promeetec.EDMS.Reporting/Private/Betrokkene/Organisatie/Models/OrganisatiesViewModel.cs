using System;
using System.Linq;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Mvc.Components.Slidepanel;
using Promeetec.EDMS.Reporting.Private.ContextMenu;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

public class OrganisatiesViewModel : ModelBase
{
    public string SearchTerm { get; set; }
    public Guid? OrganisatieId { get; set; }
    public IQueryable<OrganisatieListItemViewModel> Organisaties { get; set; }


    protected override void CreateGridContextMenuItems(GridContextMenuViewModel gridContextMenu)
    {
        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmOverzicht",
            Icon = "pm_icon_dashboard",
            Title = "Overzicht",
            Type = GridContextMenuItemType.Link,
            Url = UrlAction("Overzicht", "Organisatie", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenOrganisaties }
        });
        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmDetails",
            Icon = "pm_icon_preview",
            Title = "Details",
            Type = GridContextMenuItemType.LoadInTabbedSlidepanel,
            Url = UrlAction("Details", "Organisatie", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenOrganisaties }
        });
        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmMedewerkers",
            Icon = "pm_icon_users",
            Title = "Medewerkers",
            Type = GridContextMenuItemType.Link,
            Url = UrlAction("Medewerkers", "Organisatie", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenMedewerkers }
        });

        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmVoorraad",
            Icon = "pm_icon_voorraad",
            Title = "Voorraad",
            Type = GridContextMenuItemType.Link,
            Url = UrlAction("Voorraad", "Organisatie", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenVoorraad }
        });

        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmAanleveringen",
            Icon = "pm_icon_suitcase",
            Title = "Aanleveringen",
            Type = GridContextMenuItemType.Link,
            Url = UrlAction("Aanlevering", "Organisatie", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenAanleveringen }
        });

        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmRapportages",
            Icon = "pm_icon_rapportage",
            Title = "Rapportages",
            Type = GridContextMenuItemType.Link,
            Url = UrlAction("Rapportages", "Organisatie", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenRapportages }
        });

        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmMachtigingen",
            Icon = "pm_icon_ketenzorg",
            Title = "Machtigingen",
            Type = GridContextMenuItemType.Link,
            Url = UrlAction("Machtigingen", "Organisatie", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenMachtigingen }
        });

        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmION",
            Icon = "pm_icon_healthcare_snake",
            Title = "ION",
            Type = GridContextMenuItemType.Link,
            Url = UrlAction("ION", "Organisatie", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenION }
        });


        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmAdresboek",
            Icon = "pm_icon_addressbook",
            Title = "Adresboek",
            Type = GridContextMenuItemType.Link,
            Url = UrlAction("Adresboek", "Organisatie", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenAdresboek }
        });


        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmGliRegistraties",
            Icon = "pm_icon_registraties",
            Title = "GLI",
            Type = GridContextMenuItemType.Link,
            Url = UrlAction("GliRegistratie", "Organisatie", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenEigenGliRegistraties, RoleNames.RaadplegenGliRegistraties }
        });

        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmVerbruiksmiddelen",
            Icon = "pm_icon_prestaties",
            Title = "Verbruiksmiddelen",
            Type = GridContextMenuItemType.Link,
            Url = UrlAction("Verbruiksmiddelen", "Organisatie", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenVerbruiksmiddelPrestaties, RoleNames.RaadplegenEigenVerbruiksmiddelPrestaties }
        });


        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmHaarwerken",
            Icon = "pm_icon_hair",
            Title = "Haarwerken",
            Type = GridContextMenuItemType.Link,
            Url = UrlAction("Haarwerken", "Organisatie", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenHaarwerken }
        });

        base.CreateGridContextMenuItems(gridContextMenu);
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
            LoadUrl = UrlAction("Details", "Organisatie", new { Area = "" })
        });

        slidepanelTabs.Add(new SlidepanelTab
        {
            ClientName = "tabVektis",
            TabPaneName = "paneVektis",
            Title = "Vektis",
            Icon = "pm_icon_circle_info",
            TabPaneCssClass = "canvas",
            Active = false,
            LoadUrl = UrlAction("Vektis", "Organisatie", new { Area = "" })
        });

        if (User.IsInterneMedewerker)
        {
            slidepanelTabs.Add(new SlidepanelTab
            {
                ClientName = "tabActiviteit",
                TabPaneName = "paneActiviteit",
                Title = "Activiteit",
                Icon = "pm_icon_circle_info",
                TabPaneCssClass = "canvas",
                Active = false,
                LoadUrl = UrlAction("Activiteit", "Organisatie", new { Area = "" })
            });
        }

        base.CreateSlidepanelTabs(slidepanelTabs);
    }
}