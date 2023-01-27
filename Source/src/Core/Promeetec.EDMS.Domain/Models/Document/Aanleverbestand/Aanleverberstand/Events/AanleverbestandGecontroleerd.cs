using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Events
{
    public class AanleverbestandGecontroleerd : EventBase
    {
        public string Gecontroleerd { get; set; }
    }
}