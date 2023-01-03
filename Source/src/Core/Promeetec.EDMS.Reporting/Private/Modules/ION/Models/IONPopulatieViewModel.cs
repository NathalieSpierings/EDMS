using System;
using System.Collections.Generic;
using Promeetec.EDMS.Domain.Models.Modules.ION;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.ION.Models;

public class IONPopulatieViewModel : ModelBase
{
    public Guid MedewerkerId { get; set; }
    public Guid OrganisatieId { get; set; }
    public IONZoekopdrachtViewModel Zoekopdracht { get; set; }

    public string IONToestemmingsverklaringActivatieLink { get; set; }
    public int AantalRelaties { get; set; }

    public List<IONPatient> Relaties { get; set; } = new();
}