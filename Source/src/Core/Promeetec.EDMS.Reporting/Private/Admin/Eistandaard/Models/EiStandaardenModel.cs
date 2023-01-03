using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Eistandaard.Models;

public class EiStandaardenModel : ModelBase
{
    public IList<EiStandaardModel> EiStandaarden { get; set; } = new List<EiStandaardModel>();

    //protected override void CreateGridContextMenuItems(GridContextMenuViewModel gridContextMenu)
    //{
    //    gridContextMenu.Add(new GridContextMenu
    //    {
    //        ClientName = "cmDetails",
    //        Icon = "pm_icon_preview",
    //        Title = "Details",
    //        Type = GridContextMenuItemType.LoadInTabbedSlidepanel,
    //        Url = UrlAction("Details", "EiStandaard", new { Area = "Admin" }),
    //        Roles = new[] { RoleNames.RaadplegenEiStandaard }
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
    //        LoadUrl = UrlAction("Details", "EiStandaard", new { Area = "Admin" })
    //    });

    //    base.CreateSlidepanelTabs(slidepanel);
    //}
}