using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Reporting.Private.Document.Rapportage.Queries;

public class GetAantalRapportages : IQuery<int>
{
    public Guid OrganisatieId { get; set; }
    public UserPrincipal User { get; set; }
}