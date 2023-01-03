using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Queries;

public class GetMachtigingen : IQuery<MachtigingenViewModel>
{
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public string OrganisatieNummer { get; set; }
    public string SearchTerm { get; set; }
}