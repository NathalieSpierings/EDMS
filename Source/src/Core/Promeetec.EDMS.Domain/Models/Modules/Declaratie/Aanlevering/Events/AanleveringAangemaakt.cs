using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Events;

public class AanleveringAangemaakt : EventBase
{
    public string Status { get; set; }
    public string Jaar { get; set; }
    public string Aanleverdatum { get; set; }
    public string Referentie { get; set; }
    public string ReferentiePromeetec { get; set; }
    public string AanleverStatus { get; set; }
    public string ToevoegenBestand { get; set; }
    public string Opmerking { get; set; }
    public string Behandelaar { get; set; }
    public string Eigenaar { get; set; }
    public Guid? BehandelaarId { get; set; }
    public Guid EigenaarId { get; set; }
}