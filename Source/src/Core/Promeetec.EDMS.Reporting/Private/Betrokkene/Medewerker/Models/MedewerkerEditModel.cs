using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Domain.Models.Identity.Users;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Adres.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Persoon.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.User.Models;
using Promeetec.EDMS.Reporting.Private.Identity.Group.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

public class MedewerkerEditViewModel : PersoonCreateEditViewModel
{
    public Guid Id { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieNaam { get; set; }

    public MedewerkerSoort MedewerkerSoort { get; set; }


    [Display(Name = "AGB-code zorgverlener")]
    public string AgbCodeZorgverlener { get; set; }


    [Required(ErrorMessage = "AGB-code onderneming is verplicht.")]
    [Display(Name = "AGB-code onderneming")]
    public string AgbCodeOnderneming { get; set; }


    [StringLength(200, ErrorMessage = "{0} kan maximaal {1} tekens bevatten.")]
    public string Functie { get; set; }


    public byte[] Avatar { get; set; }


    [Display(Name = "Gebruikersnaam")]
    public string UserName { get; set; }


    [UIHint("Date")]
    [DataType(DataType.Date)]
    [Display(Name = "Laatst ingelogd op")]
    public DateTime? LaatstIngelogdOp { get; set; }


    [Display(Name = "Account activatie status")]
    public UserAccountState AccountState { get; set; }


    [Display(Name = "E-mail bevestigd")]
    public bool EmailConfirmed { get; set; }


    [Display(Name = "Twee stappen beveiliging aan")]
    public bool TwoFactorEnabled { get; set; }


    [Display(Name = "Google authenticator geactiveerd")]
    public bool GoogleAuthenticatorEnabled { get; set; }


    [Display(Name = "Google authenticator secret key")]
    public string GoogleAuthenticatorSecretKey { get; set; }


    [Display(Name = "PUK-code")]
    public string PukCode { get; set; }

    [Display(Name = "Tijdelijk wachtwoord")]
    public string TempCode { get; set; }


    [Display(Name = "Verstuur activatie e-mail")]
    public bool ActivateAccount { get; set; }


    [Display(Name = "Activatie e-mail verstuurd")]
    public bool ActivationMailSend { get; set; }


    [UIHint("DateTime")]
    [DataType(DataType.Date)]
    [Display(Name = "Activatie e-mail verstuurd op")]
    public DateTime? ActivationMailSendOn { get; set; }

    public Guid? ActivationMailSendById { get; set; }


    [Display(Name = "Activatie e-mail verstuurd door")]
    public string ActivationMailSendBy { get; set; }


    [Display(Name = "Activatie e-mail opnieuw versturen?")]
    public bool SendActivationMailAgain { get; set; }


    [Display(Name = "Google Authenticator heractiveren")]
    public bool ActivateGoogleAuthenticatorAgain { get; set; }


    [Display(Name = "ION toestemmingsverklaring activatie link")]
    public string IONToestemmingsverklaringActivatieLink { get; set; }

    [UIHint("Adres")]
    public AdresViewModel Adres { get; set; }

    public GroupSelectList GroupSelect { get; set; }


    // AGB API
    public AGB.Domain.Zorgverlener Zorgverlener { get; set; }

    public IEnumerable<GroupUser> Groups { get; set; } = new List<GroupUser>();
    public IEnumerable<UserRole> Roles { get; set; } = new List<UserRole>();

    public UserProfileViewModel UserProfile { get; set; }

    public bool HasIONAccess { get; set; }

    public bool IsInRole(string roleName)
    {
        var hasAccess = false;
        try
        {
            if (Roles.Any())
            {
                if (Roles.Any(r => r.Role.Name == roleName))
                    hasAccess = true;
            }
        }
        catch (Exception)
        {
            // ignored
        }

        return hasAccess;
    }
}