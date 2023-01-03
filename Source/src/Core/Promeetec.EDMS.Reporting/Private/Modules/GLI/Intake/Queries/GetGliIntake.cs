using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.Queries;

public class GetGliIntake : IQuery<GliIntakeViewModel>
{
    public Guid IntakeId { get; set; }
    public Guid OrganisatieId { get; set; }
}