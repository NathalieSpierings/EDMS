using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Document.Aanleverbestand.Aanleverberstand.Commands
{
    public class UpdateAanleverbestand : CommandBase
    {
        public string Periode { get; set; }
        public string Zorgstraat { get; set; }
        public string Eigenaar { get; set; }

        public Guid? AanleveringId { get; set; }
        public Guid? ZorgstraatId { get; set; }
        public Guid EigenaarId { get; set; }
    }
}