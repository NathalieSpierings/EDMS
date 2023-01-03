using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.DownloadActivity.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.DownloadActivity.Queries;

public class GetDownloadActivities : IQuery<DownloadActivitiesViewModel>
{
    public Guid? BestandId { get; set; }
    public Guid? MedewerkerId { get; set; }
    public string SearchTerm { get; set; }
}