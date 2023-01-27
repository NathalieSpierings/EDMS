using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand.Events
{
    public class EigenaarBestandGewijzigd : EventBase
    {
        public string Eigenaar { get; set; }
        public Guid EigenaarId { get; set; }
    }
}