using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Changelog.Models;

namespace Promeetec.EDMS.Reporting.Private.Changelog.Queries;

public class GetChangelogPost : IQuery<ChangelogPostViewModel>
{
    public Guid PostId { get; set; }

}
