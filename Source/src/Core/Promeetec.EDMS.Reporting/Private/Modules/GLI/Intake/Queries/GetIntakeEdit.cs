using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.Queries;

public class GetIntakeEdit : IQuery<EditIntakeViewModel>
{
    public Guid OrganisatieId { get; set; }
    public Guid IntakeId { get; set; }
}