using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Queries;

public class GetOrganisaties : IQuery<OrganisatiesViewModel>
{
    public string SearchTerm { get; set; }
    public bool IncludeDelete { get; set; }
}