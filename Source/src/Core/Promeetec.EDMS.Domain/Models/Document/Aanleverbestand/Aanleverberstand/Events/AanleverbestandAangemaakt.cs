namespace Promeetec.EDMS.Domain.Document.Aanleverbestand.Aanleverberstand.Events
{
    public class AanleverbestandAangemaakt : DomainEvent
    {
        public string Periode { get; set; }
        public string WorkFlowState { get; set; }

        public string Bestandsnaam { get; set; }
        public int Bestandsgrootte { get; set; }

        public string Zorgstraat { get; set; }
        public string Eigenaar { get; set; }
    }
}