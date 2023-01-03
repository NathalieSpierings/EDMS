using System;
using System.Collections.Generic;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Behandelplan.Models;

public class BehandelplannenViewModel : ModelBase
{
    public Guid OrganisatieId { get; set; }
    public IEnumerable<BehandelplanListItemViewModel> Behandelplannen { get; set; } = new List<BehandelplanListItemViewModel>();
}