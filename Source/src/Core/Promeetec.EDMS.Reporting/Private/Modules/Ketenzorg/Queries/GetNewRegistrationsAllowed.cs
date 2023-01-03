using System;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Queries;

public class GetNewRegistrationsAllowed : IQuery<bool>
{
    public Guid MachtigingId { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNummer { get; set; }
    public string OrganisatieNaam { get; set; }
}