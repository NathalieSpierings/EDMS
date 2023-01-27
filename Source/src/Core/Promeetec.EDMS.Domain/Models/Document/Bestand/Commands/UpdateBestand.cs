using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Document.Bestand.Commands
{
    public class UpdateBestand : CommandBase
    {
        public string FileName { get; set; }
        public Guid EigenaarId { get; set; }
    }
}