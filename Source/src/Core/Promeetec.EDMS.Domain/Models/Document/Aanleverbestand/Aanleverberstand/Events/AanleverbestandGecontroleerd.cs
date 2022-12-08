using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Events
{
    public class AanleverbestandGecontroleerd : EventBase
    {
        public string Gecontroleerd { get; set; }
    }
}