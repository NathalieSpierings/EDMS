using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekeraar.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Verzekeraar.Queries;

public class GetVerzekeraars : IQuery<VerzekeraarsViewModel>
{
    public string SearchTerm { get; set; }
    public bool IncludeInactive { get; set; }
}