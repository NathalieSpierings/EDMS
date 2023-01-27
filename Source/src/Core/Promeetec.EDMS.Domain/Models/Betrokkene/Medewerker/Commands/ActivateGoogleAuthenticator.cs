using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Users;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Commands;

public class ActivateGoogleAuthenticator : CommandBase
{
    public UserAccountState AccountState { get; set; }
    public string SecretKey { get; set; }

}
