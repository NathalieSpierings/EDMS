using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Domain.Models.Identity.Users;
using Promeetec.EDMS.Domain.Models.Shared;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Adres.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Organisatie.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.Persoon.Models;
using Promeetec.EDMS.Reporting.Private.Betrokkene.UserPofile.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.Medewerker.Models;

public class MedewerkerModel : PersoonModel
{
    public OrganisatieModel Organisatie { get; set; }


    [Display(Name = "Medewerker soort")]
    public MedewerkerSoort MedewerkerSoort { get; set; }


    [Display(Name = "AGB-code zorgverlener")]
    public string AgbCodeZorgverlener { get; set; }


    [Display(Name = "AGB-code instelling")]
    public string AgbCodeOnderneming { get; set; }


    [Display(Name = "AGB-code zorgverlener")]
    public string AgbCodeZorgverlenerDisplay => AgbCodeZorgverlener != null ? string.Concat("[", AgbCodeZorgverlener.Replace(",", "]-["), "]") : "";


    [Display(Name = "AGB-code instelling")]
    public string AgbCodeOndernemingDisplay => AgbCodeOnderneming != null ? string.Concat("[", AgbCodeOnderneming.Replace(",", "]-["), "]") : "";

    public string Functie { get; set; }
    public Status Status { get; set; }
    
    [Display(Name = "Deactivatie reden")]
    public string DeactivatieReden { get; set; }


    [Display(Name = "ION toestemmingsverklaring activatie link")]
    public string IONToestemmingsverklaringActivatieLink { get; set; }


    [Display(Name = "Gebruikersnaam")]
    public string UserName { get; set; }


    [DataType(DataType.Date)]
    [Display(Name = "Laatst ingelogd op")]
    public DateTime? LaatstIngelogdOp { get; set; }


    [Display(Name = "Account activatie status")]
    public UserAccountState AccountState { get; set; }


    [Display(Name = "Activatie e-mail verstuurd")]
    public bool ActivationMailSend { get; set; }


    [DataType(DataType.Date)]
    [Display(Name = "Activatie e-mail verstuurd op")]
    public DateTime? ActivationMailSendOn { get; set; }

    public Guid? ActivationMailSendById { get; set; }


    [Display(Name = "Activatie e-mail verstuurd door")]
    public string ActivationMailSendBy { get; set; }


    [Display(Name = "E-mail bevestigd")]
    public bool EmailConfirmed { get; set; }


    [Display(Name = "Telefoonnummer bevestigd")]
    public bool PhoneNumberConfirmed { get; set; }


    [Display(Name = "Twee stappen beveiliging aan")]
    public bool TwoFactorEnabled { get; set; }


    [Display(Name = "Google authenticator aan")]
    public bool GoogleAuthenticatorEnabled { get; set; }


    [Display(Name = "Google authenticator secret key")]
    public string GoogleAuthenticatorSecretKey { get; set; }


    [Display(Name = "PUK-code")]
    public string PukCode { get; set; }


    [Display(Name = "Tijdelijk wachtwoord")]
    public string TempCode { get; set; }


    public AdresModel Adres { get; set; }

    public IEnumerable<GroupUser> Groups { get; set; } = new List<GroupUser>();
    public IEnumerable<UserRole> Roles { get; set; } = new List<UserRole>();
    public UserProfileModel UserProfile { get; set; }

    public bool IsInterneMedewerker => MedewerkerSoort != MedewerkerSoort.Extern;
    public bool IsAdmin => IsInRole(RoleNames.Administrator);

    public bool IsActive
    {
        get
        {
            if (Status == Status.Actief && Organisatie.Status == Status.Actief)
                return true;

            return false;
        }
    }

    public bool IsRestricted
    {
        get
        {
            if (IsAdmin || IsInterneMedewerker)
                return false;

            return Organisatie.Beperkt;
        }
    }

    public bool IsInRole(string roleName)
    {
        var hasAccess = false;
        try
        {
            if (Roles.Any(r => r.Role.Name == roleName))
            {
                hasAccess = true;
            }
        }
        catch
        {
            // ignored
        }

        return hasAccess;
    }
}