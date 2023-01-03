using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

public class GekoppeldeOrganisatiesModel : ModelBase
{
    public IQueryable<OrganisatieModel> GekoppeldeOrganisaties { get; set; }
}