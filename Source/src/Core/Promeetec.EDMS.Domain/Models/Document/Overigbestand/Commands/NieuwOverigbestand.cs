namespace Promeetec.EDMS.Domain.Document.Overigbestand.Commands
{
    public class NieuwOverigbestand : DomainCommand<Overigbestand>
    {
        public DateTime AangemaaktOp { get; set; }
        public string AangemaaktDoorNaam { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string Extension { get; set; }
        public int FileSize { get; set; }
        public byte[] Data { get; set; }
        public Guid EigenaarId { get; set; }
        public string Eigenaar { get; set; }
        public Guid AanleveringId { get; set; }
        public string ReferentiePromeetec { get; set; }
        public Guid? AangemaaktDoor { get; set; }
        public DateTime? AangepastOp { get; set; }
        public Guid? AangepastDoor { get; set; }
    }
}