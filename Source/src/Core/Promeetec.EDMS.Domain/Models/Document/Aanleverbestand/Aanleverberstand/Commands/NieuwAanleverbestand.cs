namespace Promeetec.EDMS.Domain.Document.Aanleverbestand.Aanleverberstand.Commands
{
    public class NieuwAanleverbestand : DomainCommand<Aanleverbestand>
    {
        public AanleverbestandWorkflowState WorkFlowState { get; set; }
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int FileSize { get; set; }
        public string MimeType { get; set; }
        public byte[] Data { get; set; }
        public string Periode { get; set; }
        public bool Zorggroep { get; set; }



        public DateTime AangemaaktOp { get; set; }
        public string AangemaaktDoorNaam { get; set; }

        public Guid EigenaarId { get; set; }
        public Guid? ZorgstraatId { get; set; }
        public Guid? VoorraadId { get; set; }
        public Guid? AanleveringId { get; set; }
        public Guid? EiStandaardId { get; set; }


        public string Eigenaar { get; set; }
        public string Zorgstraat { get; set; }
        public Guid? AangemaaktDoor { get; set; }
        public DateTime? AangepastOp { get; set; }
        public Guid? AangepastDoor { get; set; }
        public string EiStandaard { get; set; }
        public string EiStandaardNaam { get; set; }
    }
}