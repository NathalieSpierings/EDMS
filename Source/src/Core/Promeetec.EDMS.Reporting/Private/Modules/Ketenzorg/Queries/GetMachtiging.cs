using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Queries;

public class GetMachtiging : IQuery<MachtigingViewModel>
{
    public Guid MachtigingId { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public string OrganisatieNummer { get; set; }
    public bool IncludeActiviteitGroupen { get; set; } = false;
    public bool IncludeRegistraties { get; set; } = false;
}