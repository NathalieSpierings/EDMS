using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Commands;

public class UpdateAanlevering : CommandBase
{
    public string Referentie { get; set; }
    public string ReferentiePromeetec { get; set; }
    public AanleverStatus AanleverStatus { get; set; }
    public bool ToevoegenBestand { get; set; }
    public string BehandelaarVolledigeNaam { get; set; }
    public string EigenaarVolledigeNaam { get; set; }
    public string Opmerking { get; set; }
    

    public Guid BehandelaarId { get; set; }
    public string Behandelaar { get; set; }

    public Guid EigenaarId { get; set; }
    public string Eigenaar { get; set; }
}