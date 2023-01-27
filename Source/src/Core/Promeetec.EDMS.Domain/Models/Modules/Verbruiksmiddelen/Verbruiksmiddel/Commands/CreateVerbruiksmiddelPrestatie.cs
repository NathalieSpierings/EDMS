using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Commands;

public class CreateVerbruiksmiddelPrestatie : CommandBase
{
    public string AgbCodeOnderneming { get; set; }
    public HulpmiddelenSoort HulpmiddelenSoort { get; set; }
    public VerbruiksmiddelPrestatieStatus Status { get; set; }
    public int? VerwerkMaand { get; set; }
    public int? VerwerkJaar { get; set; }
    public ProfielCode? ProfielCode { get; set; }
    public DateTime? ProfielStartdatum { get; set; }
    public DateTime? ProfielEinddatum { get; set; }
    public int? ZIndex { get; set; }
    public DateTime? PrestatieDatum { get; set; }
    public int? Hoeveelheid { get; set; }

    public Guid EigenaarId { get; set; }
    public string EigenaarVolledigeNaam { get; set; }

    public Guid VerzekerdeId { get; set; }
    public string VerzekerdeVolledigeNaam { get; set; }
}