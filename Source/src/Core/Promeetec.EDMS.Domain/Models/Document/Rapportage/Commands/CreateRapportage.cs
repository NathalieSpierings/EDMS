using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Document.Rapportage.Commands
{
    public class CreateRapportage : CommandBase
    {
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string Extension { get; set; }
        public int FileSize { get; set; }
        public byte[] Data { get; set; }
        public RapportageSoort RapportageSoort { get; set; }
        public string Referentie { get; set; }
        public Guid EigenaarId { get; set; }
        public string EigenaarVolledigeNaam { get; set; }
    }
}