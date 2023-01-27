using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Commands
{
    public class CreateAanleverbestand : CommandBase
    {
        public string FileName { get; set; }
        public string Extension { get; set; }
        public int FileSize { get; set; }
        public string MimeType { get; set; }
        public byte[] Data { get; set; }
        public string Periode { get; set; }
        public Guid? AanleveringId { get; set; }

        public Guid EigenaarId { get; set; }
        public string EigenaarVolledigeNaam { get; set; }

        public Guid? EiStandaardId { get; set; }
        public string EiStandaardCode { get; set; }
        public string EiStandaardNaam { get; set; }

        public Guid? ZorgstraatId { get; set; }
        public string ZorgstraatNaam { get; set; }

    }
}