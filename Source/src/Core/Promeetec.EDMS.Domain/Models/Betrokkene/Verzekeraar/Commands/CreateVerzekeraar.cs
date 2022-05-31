using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekeraar.Commands
{
    public class CreateVerzekeraar : CommandBase
    {
        public short Uzovi { get; set; }
        public string Naam { get; set; }
        public bool Actief { get; set; }
    }
}