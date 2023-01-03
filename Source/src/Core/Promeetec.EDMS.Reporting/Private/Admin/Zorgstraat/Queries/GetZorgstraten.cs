using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.Zorgstraat.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Zorgstraat.Queries;

public class GetZorgstraten : IQuery<ZorgstratenViewModel>
{
    public string SearchTerm { get; set; }
    public bool IncludeDeletes { get; set; }
}