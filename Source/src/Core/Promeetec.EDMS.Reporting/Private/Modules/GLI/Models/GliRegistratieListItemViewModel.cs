using System;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Models;

public class GliRegistratieListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid OrganisatieId { get; set; }
    public Guid VerzekerdeId { get; set; }
    public string VerzekerdeFormeleNaam { get; set; }
    public double? VerzekerdeLengte { get; set; }
    public string Bsn { get; set; }
    public DateTime? Geboortedatum { get; set; }
    public DateTime IntakeDatum { get; set; }
    public bool Verwerkt { get; set; }
    public DateTime? VerwerktOp { get; set; }
    public GliStatus GliStatus { get; set; }
    public bool IsFase1Gestart { get; set; }
}