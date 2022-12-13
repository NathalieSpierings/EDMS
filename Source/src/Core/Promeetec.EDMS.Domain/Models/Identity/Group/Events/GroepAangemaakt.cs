using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Identity.Group.Events;

public class GroepAangemaakt : EventBase
{
    public string Status { get; set; }
    public string Naam { get; set; }
    public string Omschrijving { get; set; }
}