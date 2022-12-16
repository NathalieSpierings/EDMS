﻿using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Commands;

public class UpdateVerbruiksmiddelPrestatie : CommandBase
{
    public string AgbCodeOnderneming { get; set; }
    public HulpmiddelenSoort HulpmiddelenSoort { get; set; }
    public VerbruiksmiddelPrestatieStatus Status { get; set; }
    public int? VerwerkMaand { get; set; }
    public int? VerwerkJaar { get; set; }
    public int? ProfielCode { get; set; }
    public DateTime? ProfielStartdatum { get; set; }
    public DateTime? ProfielEinddatum { get; set; }
    public int? ZIndex { get; set; }
    public DateTime? PrestatieDatum { get; set; }
    public int? Hoeveelheid { get; set; }
    public Guid VerzekerdeId { get; set; }
}