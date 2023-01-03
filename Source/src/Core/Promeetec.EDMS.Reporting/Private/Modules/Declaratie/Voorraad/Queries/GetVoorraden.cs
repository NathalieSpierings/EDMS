using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Voorraad.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Declaratie.Voorraad.Queries;

public class GetVoorraden : IQuery<VoorradenViewModel>
{
    public string SearchTerm { get; set; }
}