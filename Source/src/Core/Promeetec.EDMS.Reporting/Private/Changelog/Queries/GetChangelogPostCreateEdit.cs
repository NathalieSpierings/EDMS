using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Changelog.Models;

namespace Promeetec.EDMS.Reporting.Private.Changelog.Queries;

public class GetChangelogPostCreateEdit : IQuery<ChangelogPostCreateEditViewModel>
{
    public Guid PostId { get; set; }

}
