using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekeraar.Events;

public class VerzekeraarAangemaakt : EventBase
{
    public string Uzovi { get; set; }
    public string Naam { get; set; }
    public string Actief { get; set; }
}