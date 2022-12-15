using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Commands;

public class CreateAanlevering : CommandBase
{
    public string Referentie { get; set; }
    public string ReferentiePromeetec { get; set; }
    public bool ToevoegenBestand { get; set; }
    public string Opmerking { get; set; }


    public Guid BehandelaarId { get; set; }
    public string Behandelaar { get; set; }

    public Guid EigenaarId { get; set; }
    public string Eigenaar { get; set; }

}