using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Events;

public class GoogleAuthenticatorGeheractiveerd : EventBase
{
    public string AccountStatus { get; set; }
    public string? GoogleAuthenticatorSecretKey { get; set; }
    public string GoogleAuthenticatorAan { get; set; }
    public string TwoFactorAuthentieAan { get; set; }

}
