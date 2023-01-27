using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekeraar.Commands
{
    public class CreateVerzekeraar : CommandBase
    {
        public short Uzovi { get; set; }
        public string Naam { get; set; }
        public bool Actief { get; set; }
    }
}