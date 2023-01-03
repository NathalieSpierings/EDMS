using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Behandelplan.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Behandelplan.Queries;

public class GetBehandelplanStop : IQuery<StopBehandelplanViewModel>
{
    public Guid OrganisatieId { get; set; }
    public Guid IntakeId { get; set; }
}