using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Verbruiksmiddel.Queries;

public class GetVerbruiksmiddelPrestaties : IQuery<VerbruiksmiddelPrestatiesViewModel>
{
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public bool Processed { get; set; }
    public string SearchTerm { get; set; }
    public UserPrincipal User { get; set; }
}