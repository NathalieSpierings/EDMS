using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Events
{
    public class AanleverbestandOngecontroleerd : EventBase
    {
        public string Gecontroleerd { get; set; }
    }
}