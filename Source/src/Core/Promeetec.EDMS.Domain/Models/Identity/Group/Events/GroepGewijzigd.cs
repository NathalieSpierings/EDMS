using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Identity.Group.Events;

public class GroepGewijzigd : EventBase
{
    public string Naam { get; set; }
    public string Omschrijving { get; set; }
}