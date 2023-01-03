using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.RedenEindeZorg.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.RedenEindeZorg.Queries;

public class GetRedenenEindeZorg : IQuery<RedenenEindeZorgViewModel>
{
    public string SearchTerm { get; set; }

    public bool IncludeDeletes { get; set; }
}