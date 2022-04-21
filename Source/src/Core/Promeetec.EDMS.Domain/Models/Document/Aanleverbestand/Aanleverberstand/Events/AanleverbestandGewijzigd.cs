namespace Promeetec.EDMS.Domain.Document.Aanleverbestand.Aanleverberstand.Events
{
    public class AanleverbestandGewijzigd : DomainEvent
    {
        public string Periode { get; set; }
        public string Zorgstraat { get; set; }
        public string Eigenaar { get; set; }
    }
}