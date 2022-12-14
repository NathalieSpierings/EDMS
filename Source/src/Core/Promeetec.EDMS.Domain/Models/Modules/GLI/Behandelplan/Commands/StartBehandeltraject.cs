﻿using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.Gli.Behandelplan.Commands;

public class StartBehandeltraject : CommandBase
{
    public DateTime Startdatum { get; set; }
    public DateTime Einddatum { get; set; }
    public GliProgramma Programma { get; set; }
    public GliBehandelfase Fase { get; set; }
    public string Opmerking { get; set; }
    public GliStatus GliStatus { get; set; }
    public Guid BehandelaarId { get; set; }
    public Guid VerzekerdeId { get; set; }
    public Guid IntakeId { get; set; }

}