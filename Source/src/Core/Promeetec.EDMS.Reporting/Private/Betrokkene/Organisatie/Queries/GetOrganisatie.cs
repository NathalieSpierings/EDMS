using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Queries;

public class GetOrganisatie : IQuery<OrganisatieModel>
{
    public Guid OrganisatieId { get; set; }
    public bool IncludeGekoppeldeOrganisaties { get; set; } = false;
}