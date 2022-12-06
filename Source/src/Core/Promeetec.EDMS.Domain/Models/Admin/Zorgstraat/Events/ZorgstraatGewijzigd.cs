using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Admin.Zorgstraat.Events;

public class ZorgstraatGewijzigd : EventBase
{
    public string Naam { get; set; }
}