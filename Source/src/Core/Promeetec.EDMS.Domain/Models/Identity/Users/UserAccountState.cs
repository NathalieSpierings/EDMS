using System.ComponentModel.DataAnnotations;

namespace Promeetec.EDMS.Domain.Models.Identity.Users;

public enum UserAccountState
{
    [Display(Name = "In afwachting van activering")]
    Pending = 0,

    [Display(Name = "E-mail bevestigd")]
    EmailConfirmed = 1,

    [Display(Name = "Google authenticator geactiveerd")]
    GoogleAuthenticatorAcivated = 2,

    [Display(Name = "Geactiveerd")]
    Activated = 3,

    Test = 4,

    [Display(Name = "In afwachting van Google authenticator heractivatie")]
    ReactivateGoogleAuthenticator = 5
}