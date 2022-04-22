using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Identity.Users;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;

public class ActivateGoogleAuthenticator : CommandBase
{
    public UserAccountState AccountState { get; set; }
    public string SecretKey { get; set; }

}
