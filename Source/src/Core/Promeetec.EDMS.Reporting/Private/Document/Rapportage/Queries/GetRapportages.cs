using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Document.Rapportage.Models;

namespace Promeetec.EDMS.Reporting.Private.Document.Rapportage.Queries;

public class GetRapportages : IQuery<RapportagesViewModel>
{
    public Guid? OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }
    public Guid? EigenaarId { get; set; }
    public Guid? BehandelaarId { get; set; }
    public string SearchTerm { get; set; }
    public UserPrincipal User { get; set; }
}