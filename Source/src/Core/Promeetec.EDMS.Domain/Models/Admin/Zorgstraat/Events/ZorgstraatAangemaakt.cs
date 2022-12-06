using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Events;

public class ZorgstraatAangemaakt : EventBase
{
    public string Naam { get; set; }
    public string Status { get; set; }

}