using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.Zorgstraat.Events;

public class ZorgstraatAangemaakt : EventBase
{
    public string Naam { get; set; }
    public string Status { get; set; }

}