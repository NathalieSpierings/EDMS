using System;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.Queries;

public class GetIntakes : IQuery<IntakesViewModel>
{
    public Guid OrganisatieId { get; set; }
    public string SearchTerm { get; set; }
    public UserPrincipal User { get; set; }
}