using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekeraar.Events;

public class VerzekeraarAangemaakt : EventBase
{
    public string Uzovi { get; set; }
    public string Naam { get; set; }
    public string Actief { get; set; }
}