using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Queries;

public class GetGekoppeldeOrganisaties : IQuery<GekoppeldeOrganisatiesModel>
{
    public Guid ZorggroepId { get; set; }
}