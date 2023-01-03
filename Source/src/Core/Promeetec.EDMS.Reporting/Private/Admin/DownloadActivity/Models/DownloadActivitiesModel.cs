using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.DownloadActivity.Models;

public class DownloadActivitiesModel : ModelBase
{
    public string SearchTerm { get; set; }
    public IEnumerable<DownloadActivityListItemModel> Downloads { get; set; } = new List<DownloadActivityListItemModel>();
}