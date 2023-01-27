using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand.Commands
{
    public class UpdateEigenaarBestand : CommandBase
    {
        public Guid EigenaarId { get; set; }
    }
}