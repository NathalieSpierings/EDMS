using Microsoft.AspNetCore.Identity;
using Promeetec.EDMS.Domain.Domain.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Domain.Identity;
using Promeetec.EDMS.Domain.Domain.Identity.Group;
using Promeetec.EDMS.Domain.Domain.Identity.Role;
using Promeetec.EDMS.Domain.Domain.Identity.Users;
using Promeetec.EDMS.Domain.Domain.Shared;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promeetec.EDMS.Domain.Domain.Betrokkene.Medewerker;

public class Medewerker : IdentityUser<Guid>
{
    /// <summary>
    /// The status of the medewerker.
    /// <list type="bullet">
    /// <item>
    /// <description>Inactief: Medewerker cannot login.</description>
    /// </item>
    /// <item>
    /// <description>Actief: Medewerker can login.</description>
    /// </item>
    /// </list>
    /// </summary>
    public Status Status { get; private set; }


    /// <summary>
    /// The type of medewerker.
    /// Can be either internal or external.
    /// </summary>
    public MedewerkerSoort MedewerkerSoort { get; private set; }


    /// <summary>
    /// The persoon details.
    /// </summary>
    public virtual EDMS.Domain.Betrokkene.Persoon.Persoon Persoon { get; private set; }


    /// <summary>
    /// The Vektis agbcode zorgverlener for the medewerker.
    /// </summary>
    [StringLength(20)]
    public string AgbCodeZorgverlener { get; private set; }


    /// <summary>
    /// The Vektis agbcode onderneming for the medewerker.
    /// </summary>
    [StringLength(20)]
    public string AgbCodeOnderneming { get; private set; }


    /// <summary>
    /// The job title  for the medewerker.
    /// </summary>
    [StringLength(200)]
    public string Functie { get; private set; }


    /// <summary>
    /// The avatar  for the medewerker.
    /// </summary>
    [MaxLength]
    [Column(TypeName = "varbinary(max)")]
    public byte[] Avatar { get; private set; }


    /// <summary>
    /// The suspension reason for the medewerker.
    /// </summary>
    [StringLength(450)]
    public string DeactivatieReden { get; private set; }


    /// <summary>
    /// The ION toestemmingsverklaring activation link for this medewerker.
    /// </summary>
    public string IONToestemmingsverklaringActivatieLink { get; private set; }


    /// <summary>
    /// The time stamp of the last login for this user.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? LaatstIngelogdOp { get; private set; }


    /// <summary>
    /// The time stamp of the previous login for this user.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? VorigeLoginOp { get; private set; }


    /// <summary>
    /// The account state of the user.
    /// <list type="bullet">
    /// <item>
    /// <description>Pending: Medewerker is registered but the activation of the account has not been started.</description>
    /// </item>
    /// <item>
    /// <description>EmailConfirmed: Medewerker has not confirmd it's e-mail.</description>
    /// </item>
    /// <item>
    /// <description>GoogleAuthenticatorAcivated: Medewerker has google authenticator configured.</description>
    /// </item>
    /// <item>
    /// <description>Activated: Medewerker has 2FA configured.</description>
    /// </item>
    /// <item>
    /// <description>Test: Test users login without 2FA.</description>
    /// </item>
    /// <item>
    /// <description>ReactivateGoogleAuthenticator: The medewerker must reactivate google authenticator.</description>
    /// </item>
    /// </list>
    /// </summary>
    public UserAccountState AccountState { get; private set; }


    /// <summary>
    /// Value indicating if Google authenticator is enabled for this medewerker.
    /// </summary>
    public bool GoogleAuthenticatorEnabled { get; private set; }


    /// <summary>
    /// The Google authenticator secret key for this medewerker.
    /// </summary>
    [StringLength(200)]
    public string GoogleAuthenticatorSecretKey { get; private set; }


    /// <summary>
    /// The temporary password for this medewerker.
    /// </summary>
    [StringLength(200)]
    public string TempCode { get; private set; }


    /// <summary>
    /// The PUK-code for this medewerker.
    /// </summary>
    [StringLength(200)]
    public string PukCode { get; private set; }


    /// <summary>
    /// Value indicating if the activation email has been send.
    /// </summary>
    public bool ActivationMailSend { get; private set; }


    /// <summary>
    /// The time stamp of when the activation email has been send.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? ActivationMailSendOn { get; private set; }


    /// <summary>
    /// The time stamp of when the record has been created.
    /// </summary>
    public DateTime TimeStamp { get; private set; }

    public Guid? AangemaaktDoorId { get; private set; }
    public string AangemaaktDoor { get; private set; }


    #region Navigation properties


    /// <summary>
    /// The unique identifier of the medewerker who sended the activation email.
    /// </summary>
    [ForeignKey("ActivationMailSendBy")]
    public Guid? ActivationMailSendById { get; private set; }


    /// <summary>
    /// Reference to the medewerker who send the activation email.
    /// </summary>
    public Medewerker ActivationMailSendBy { get; set; }


    /// <summary>
    /// The unique identifier of the organisatie who the medewerker belongs to.
    /// </summary>
    public Guid OrganisatieId { get; private set; }

    /// <summary>
    /// Reference to the organisatie who the medewerker belongs to.
    /// </summary>
    public Organisatie.Organisatie Organisatie { get; set; }


    /// <summary>
    /// The unique identifier of the adres for the medewerker.
    /// </summary>
    public Guid? AdresId { get; private set; }

    /// <summary>
    /// Reference to the address for the medewerker.
    /// </summary>
    public Adres.Adres Adres { get; set; }

    /// <summary>
    /// Reference to the user profile for the medewerker.
    /// </summary>
    public UserProfile.UserProfile UserProfile { get; set; }


    public ICollection<GroupUser> Groups { get; set; } = new List<GroupUser>();
    public ICollection<UserRole> Roles { get; set; } = new List<UserRole>();
    public ICollection<VerzekerdeToUser> Verzekerden { get; set; } = new List<VerzekerdeToUser>();
    public ICollection<Memo.Memo> Memos { get; set; } = new List<Memo.Memo>();

    public ICollection<UserClaim> Claims { get; set; }
    public ICollection<UserLogin> Logins { get; set; }
    public ICollection<UserToken> Tokens { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }


    #endregion


    public bool IsInterneMedewerker => MedewerkerSoort != MedewerkerSoort.Extern;
    public bool IsAdmin => IsInRole(RoleNames.Administrator);
    public bool IsBeheerder => IsInGroup(GroupNames.Beheerders);

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

    public bool IsInGroup(string groupName)
    {
        var hasAccess = false;
        try
        {
            if (Groups.Any(g => g.Group.Name == groupName))
                hasAccess = true;
        }
        catch
        {
            // ignored
        }

        return hasAccess;
    }


    /// <summary>
    /// Creates an empty medewerker.
    /// </summary>
    public Medewerker()
    {
    }
}
