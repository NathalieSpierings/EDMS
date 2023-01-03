using System;
using System.Collections.Generic;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Adresboek.Models;

public class AdresboekClientenViewModel : ModelBase
{
    public Guid AdresboekId { get; set; }
    public Guid OrganisatieId { get; set; }
    public int AantalClienten { get; set; }
    public int AantalClientenMetProfiel { get; set; }
    public IList<AdresboekClientListViewModel> Clienten { get; set; } = new List<AdresboekClientListViewModel>();
}