using System.Collections.Generic;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Changelog.Models;

public class ChangelogViewModel : ModelBase
{
    public IList<ChangelogPostViewModel> Posts { get; set; }
}