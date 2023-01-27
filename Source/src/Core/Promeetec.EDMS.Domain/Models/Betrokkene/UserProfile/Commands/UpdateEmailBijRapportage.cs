using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.UserProfile.Commands
{
    public class UpdateEmailBijRapportage : CommandBase
    {
        public bool EmailBijRapportage { get; set; }
    }
}