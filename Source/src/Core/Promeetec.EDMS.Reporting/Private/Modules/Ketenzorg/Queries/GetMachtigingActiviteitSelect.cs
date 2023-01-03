using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Queries;

public class GetMachtigingActiviteitSelect : IQuery<MachtigingActiviteitSelectViewModel>
{
    public Guid MachtigingId { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public string OrganisatieNummer { get; set; }
}