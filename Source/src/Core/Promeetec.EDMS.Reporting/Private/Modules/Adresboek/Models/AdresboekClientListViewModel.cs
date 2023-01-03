using System;
using Promeetec.EDMS.Domain.Models.Betrokkene.Persoon;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.Adresboek.Models;

public class AdresboekClientListViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid OrganisatieId { get; set; }
    public Guid AdresboekId { get; set; }
    public Status Status { get; set; }
    public bool Shared { get; set; }
    public Geslacht Geslacht { get; set; }
    public DateTime Geboortedatum { get; set; }

    public string VolledigeNaam { get; set; }
    public string Achternaam { get; set; }
    public bool HasZorgprofiel { get; set; }
}