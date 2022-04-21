namespace Promeetec.EDMS.Domain.Document.Bestand.Commands
{
    public class NieuwBestand : DomainCommand<Bestand>
    {
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public string Extension { get; set; }
        public string MimeType { get; set; }
        public byte[] Data { get; set; }
        public DateTime AangemaaktOp { get; set; }
        public Guid? AangemaaktDoor { get; set; }
        public string AangemaaktDoorNaam { get; set; }
        public DateTime? AangepastOp { get; set; }
        public Guid? AangepastDoor { get; set; }
        public Guid EigenaarId { get; set; }
    }
}