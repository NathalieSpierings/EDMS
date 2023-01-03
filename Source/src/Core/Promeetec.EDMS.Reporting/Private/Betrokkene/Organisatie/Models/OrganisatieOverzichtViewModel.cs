using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Mvc.Components.Slidepanel;
using Promeetec.EDMS.Reporting.Private.ContextMenu;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

public class OrganisatieOverzichtViewModel : ModelBase
{
    public OrganisatieViewModel Organisatie { get; set; }


    protected override void CreateGridContextMenuItems(GridContextMenuViewModel gridContextMenu)
    {
        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmDetails",
            Icon = "pm_icon_preview",
            Title = "Details",
            Active = true,
            Type = GridContextMenuItemType.LoadInTabbedSlidepanel,
            RouteValues = new { id = Organisatie.Id },
            Url = UrlAction("Details", "Organisatie", new { Area = "", id = Organisatie.Id }),
            Roles = new[] { RoleNames.RaadplegenOrganisaties }
        });

        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmMedewerkers",
            Icon = "pm_icon_users",
            Title = "Medewerkers",
            Active = true,
            Type = GridContextMenuItemType.Link,
            RouteValues = new { id = Organisatie.Id },
            Url = UrlAction("Medewerkers", "Organisatie", new { Area = "", id = Organisatie.Id, organisatieNaam = Organisatie.Naam }),
            Roles = new[] { RoleNames.RaadplegenMedewerkers }
        });


        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmVoorraad",
            Icon = "pm_icon_voorraad",
            Title = "Voorraad",
            Active = true,
            Type = GridContextMenuItemType.Link,
            RouteValues = new { id = Organisatie.Id },
            Url = UrlAction("Voorraad", "Organisatie", new { Area = "", id = Organisatie.Id }),
            Roles = new[] { RoleNames.RaadplegenVoorraad }
        });


        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmAanleveringen",
            Icon = "pm_icon_suitcase",
            Title = "Aanleveringen",
            Active = true,
            Type = GridContextMenuItemType.Link,
            RouteValues = new { id = Organisatie.Id },
            Url = UrlAction("Aanlevering", "Organisatie", new { Area = "", id = Organisatie.Id }),
            Roles = new[] { RoleNames.RaadplegenAanleveringen }
        });

        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmRapportages",
            Icon = "pm_icon_rapportage",
            Title = "Rapportages",
            Active = true,
            Type = GridContextMenuItemType.Link,
            RouteValues = new { id = Organisatie.Id },
            Url = UrlAction("Rapportages", "Organisatie", new { Area = "", id = Organisatie.Id, organisatieNaam = Organisatie.Naam }),
            Roles = new[] { RoleNames.RaadplegenRapportages, RoleNames.RaadplegenEigenRapportages }
        });

        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmcmMachtigingen",
            Icon = "pm_icon_ketenzorg",
            Title = "Machtigingen",
            Active = true,
            Type = GridContextMenuItemType.Link,
            RouteValues = new { id = Organisatie.Id },
            Url = UrlAction("Machtigingen", "Organisatie", new { Area = "", id = Organisatie.Id, organisatieNummer = Organisatie.Nummer, organisatieNaam = Organisatie.Naam }),
            Roles = new[] { RoleNames.RaadplegenMachtigingen }
        });

        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmION",
            Icon = "pm_icon_healthcare_snake",
            Title = "ION",
            Active = true,
            Type = GridContextMenuItemType.Link,
            RouteValues = new { id = Organisatie.Id },
            Url = UrlAction("ION", "Organisatie", new { Area = "", id = Organisatie.Id, organisatieNaam = Organisatie.Naam }),
            Roles = new[] { RoleNames.RaadplegenION }
        });

        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmAdresboek",
            Icon = "pm_icon_addressbook",
            Title = "Adresboek",
            Active = true,
            Type = GridContextMenuItemType.Link,
            RouteValues = new { id = Organisatie.Id },
            Url = UrlAction("Adresboek", "Organisatie", new { Area = "", id = Organisatie.Id, adresboekId = Organisatie.AdresboekId, organisatieNaam = Organisatie.Naam }),
            Roles = new[] { RoleNames.RaadplegenAdresboek }
        });


        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmGliRegistraties",
            Icon = "pm_icon_registraties",
            Title = "GLI",
            Active = true,
            Type = GridContextMenuItemType.Link,
            RouteValues = new { id = Organisatie.Id },
            Url = UrlAction("GliRegistratie", "Organisatie", new { Area = "", id = Organisatie.Id, organisatieNaam = Organisatie.Naam }),
            Roles = new[] { RoleNames.RaadplegenEigenGliRegistraties, RoleNames.RaadplegenGliRegistraties }
        });


        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmVerbruiksmiddelen",
            Icon = "pm_icon_prestaties",
            Title = "Verbruiksmiddelen",
            Active = true,
            Type = GridContextMenuItemType.Link,
            RouteValues = new { id = Organisatie.Id },
            Url = UrlAction("Verbruiksmiddelen", "Organisatie", new { Area = "", id = Organisatie.Id, organisatieNaam = Organisatie.Naam, adresboekId = Organisatie.AdresboekId }),
            Roles = new[] { RoleNames.RaadplegenVerbruiksmiddelPrestaties, RoleNames.RaadplegenEigenVerbruiksmiddelPrestaties }
        });

        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmHaarwerken",
            Icon = "pm_icon_hair",
            Title = "Haarwerken",
            Active = true,
            Type = GridContextMenuItemType.Link,
            RouteValues = new { id = Organisatie.Id },
            Url = UrlAction("Haarwerken", "Organisatie", new { Area = "", id = Organisatie.Id, organisatieNaam = Organisatie.Naam }),
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
            LoadUrl = UrlAction("Details", "Organisatie", new { Area = "" })
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
                LoadUrl = UrlAction("Activiteit", "Organisatie", new { Area = "" })
            });
        }

        base.CreateSlidepanelTabs(slidepanel);
    }
}