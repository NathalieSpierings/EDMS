using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Document.Bestand.Commands
{
    public class UpdateBestand : CommandBase
    {
        public string FileName { get; set; }
        public Guid EigenaarId { get; set; }
    }
}