using System;
using System.Collections.Generic;
using Promeetec.EDMS.Reporting.Private.Admin.DownloadActivity.Models;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Overigbestand.Models;

public class OverigbestandenViewModel : ModelBase
{
    public Guid AanleveringId { get; set; }
    public DownloadActivitiesModel DownloadActivities { get; set; }
    public IEnumerable<OverigbestandListItemViewModel> Overigbestanden { get; set; }
}