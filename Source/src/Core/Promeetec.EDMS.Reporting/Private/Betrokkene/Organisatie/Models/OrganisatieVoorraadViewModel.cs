using System;
using System.Linq;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Mvc.Components.Slidepanel;
using Promeetec.EDMS.Reporting.Private.ContextMenu;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

public class OrganisatieVoorraadViewModel : ModelBase
{
    // Only used for Details View
    public Guid? DetailId { get; set; }
    public OrganisatieViewModel Organisatie { get; set; }
    public IQueryable<OrganisatieVoorraadListItemViewModel> Voorraadbestanden { get; set; }


    private int _aantal;
    public int AantalVoorraadbestanden
    {
        get
        {
            if (Voorraadbestanden != null && Voorraadbestanden.Count() != 0)
                _aantal = Voorraadbestanden.Count();

            return _aantal;
        }
        set => _aantal = value;
    }



    protected override void CreateGridContextMenuItems(GridContextMenuViewModel gridContextMenu)
    {
        gridContextMenu.Add(new GridContextMenu
        {
            ClientName = "cmDetails",
            Icon = "pm_icon_preview",
            Title = "Details",
            Type = GridContextMenuItemType.LoadInTabbedSlidepanel,
            Url = UrlAction("VoorraadbestandDetails", "Bestand", new { Area = "" }),
            Roles = new[] { RoleNames.RaadplegenAanleverbestanden, RoleNames.RaadplegenEigenAanleverbestanden }
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
            LoadUrl = UrlAction("VoorraadbestandDetails", "Bestand", new { Area = "" })
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
                LoadUrl = UrlAction("VoorraadbestandActiviteit", "Bestand", new { Area = "" })
            });
        }

        base.CreateSlidepanelTabs(slidepanel);
    }
}