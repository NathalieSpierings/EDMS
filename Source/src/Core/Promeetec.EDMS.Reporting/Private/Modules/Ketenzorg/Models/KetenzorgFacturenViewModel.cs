using System;
using System.Collections.Generic;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Ketenzorg.Models;

/// <summary>
/// Represents a viewmodel based on the Activity class.
/// </summary>
public class KetenzorgFacturenViewModel : ModelBase
{
    public string ApiError { get; set; }

    public Guid OrganisatieId { get; set; }
    public string OrganisatieNummer { get; set; }
    public string OrganisatieNaam { get; set; }
    public bool OrganisatieHasAnAddress { get; set; }
    public List<MachtigingFacturenListItemViewModel> Facturen { get; set; } = new();
}