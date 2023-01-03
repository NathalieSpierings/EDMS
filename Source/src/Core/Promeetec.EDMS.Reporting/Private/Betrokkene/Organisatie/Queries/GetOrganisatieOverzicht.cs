using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Queries;

public class GetOrganisatieOverzicht : IQuery<OrganisatieOverzichtViewModel>
{
    public Guid OrganisatieId { get; set; }
}