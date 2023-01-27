using Promeetec.EDMS.Portaal.Reporting.Shared.Models;

namespace Promeetec.EDMS.Portaal.Reporting.Private.Betrokkene.Organisatie.Models;

public class GekoppeldeOrganisatiesModel : ModelBase
{
    public IQueryable<OrganisatieModel> GekoppeldeOrganisaties { get; set; }
}