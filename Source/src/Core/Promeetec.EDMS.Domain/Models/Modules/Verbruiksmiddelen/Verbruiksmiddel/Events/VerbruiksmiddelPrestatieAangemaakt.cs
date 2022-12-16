using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Events;

public class VerbruiksmiddelPrestatieAangemaakt : EventBase
{
    public string AgbCodeOnderneming { get; set; }
    public string HulpmiddelenSoort { get; set; }
    public string Status { get; set; }
    public string? VerwerkMaand { get; set; }
    public string? VerwerkJaar { get; set; }
    public string? ProfielCode { get; set; }
    public string? ProfielStartdatum { get; set; }
    public string? ProfielEinddatum { get; set; }
    public string? ZIndex { get; set; }
    public string? PrestatieDatum { get; set; }
    public string? Hoeveelheid { get; set; }
    public Guid EigenaarId { get; set; }
    public string EigenaarVolledigeNaam { get; set; }
    public Guid VerzekerdeId { get; set; }
    public string VerzekerdeVolledigeNaam { get; set; }
}