using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Queries;

public class GetOrganisatieVoorraad : IQuery<OrganisatieVoorraadViewModel>
{
    public Guid OrganisatieId { get; set; }
    public string SearchTerm { get; set; }
    public UserPrincipal User { get; set; }

}