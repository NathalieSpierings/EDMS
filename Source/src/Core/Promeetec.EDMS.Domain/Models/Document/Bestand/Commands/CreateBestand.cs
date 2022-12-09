using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Document.Bestand.Commands
{
    public class CreateBestand : CommandBase
    {
        public string FileName { get; set; }
        public int FileSize { get; set; }
        public string Extension { get; set; }
        public string MimeType { get; set; }
        public byte[] Data { get; set; }
        public Guid EigenaarId { get; set; }
        public string EigenaarVolledigeNaam { get; set; }
    }
}