using System;
using System.Collections.Generic;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Intake.Models;

public class IntakesViewModel : ModelBase
{
    public Guid OrganisatieId { get; set; }
    public IEnumerable<GliIntakeListItemViewModel> Intakes { get; set; } = new List<GliIntakeListItemViewModel>();
}