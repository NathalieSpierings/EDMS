using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Haarwerk.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Haarwerk.Queries;

public class GetHaarwerken : IQuery<HaarwerkenViewModel>
{
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public string SearchTerm { get; set; }
    public bool Processed { get; set; }
}
