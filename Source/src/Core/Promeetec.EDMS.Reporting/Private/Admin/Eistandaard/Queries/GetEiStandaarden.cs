using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Admin.Eistandaard.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Eistandaard.Queries;

public class GetEiStandaarden : IQuery<EiStandaardenViewModel>
{
    public string SearchTerm { get; set; }
}