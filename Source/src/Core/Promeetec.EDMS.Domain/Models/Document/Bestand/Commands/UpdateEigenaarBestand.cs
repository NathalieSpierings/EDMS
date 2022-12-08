using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Document.Bestand.Commands
{
    public class UpdateEigenaarBestand : CommandBase
    {
        public Guid EigenaarId { get; set; }
    }
}