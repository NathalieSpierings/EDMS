using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Land.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Land.Queries;

public class GetLanden : IQuery<LandenViewModel>
{
    public string SearchTerm { get; set; }
}