using System;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Modules.GLI.Behandelplan.Models;

public class BehandelplanListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public Guid IntakeId { get; set; }
    public Guid VerzekerdeId { get; set; }
    public Guid OrganisatieId { get; set; }

    public DateTime Startdatum { get; set; }
    public DateTime Einddatum { get; set; }

    public GliProgramma GliProgramma { get; set; }
    public GliBehandelfase Fase { get; set; }
    public GliStatus GliStatus { get; set; }
    public bool VoortijdigGestopt { get; set; }
    public DateTime? VoortijdigeStopdatum { get; set; }

    public string VerzekerdeFormeleNaam { get; set; }
    public string Bsn { get; set; }
    public string AgbCodeVerwijzer { get; set; }
    public string NaamVerwijzer { get; set; }
    public bool Verwerkt { get; set; }
    public DateTime? VerwerktOp { get; set; }

}