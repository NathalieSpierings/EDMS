using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Overigbestand.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Overigbestand.Queries;

public class GetOverigbestanden : IQuery<OverigbestandenViewModel>
{
    public Guid AanleveringId { get; set; }
    public UserPrincipal User { get; set; }
    public bool IncludeDownloadActivities { get; set; } = false;
}