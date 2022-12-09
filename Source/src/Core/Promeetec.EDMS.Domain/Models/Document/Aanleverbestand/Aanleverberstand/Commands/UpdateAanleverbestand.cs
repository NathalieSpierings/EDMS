using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Commands
{
    public class UpdateAanleverbestand : CommandBase
    {
        public string Periode { get; set; }

        public Guid? AanleveringId { get; set; }

        public Guid? ZorgstraatId { get; set; }
        public string ZorgstraatNaam { get; set; }

        public Guid EigenaarId { get; set; }
        public string EigenaarVolledigeNaam { get; set; }

    }
}