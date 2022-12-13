using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Identity.Group.Events;

public class GroepGewijzigd : EventBase
{
    public string Naam { get; set; }
    public string Omschrijving { get; set; }
}