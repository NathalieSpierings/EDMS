using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;
using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Domain.Models.Identity.Group;
using Promeetec.EDMS.Domain.Models.Identity.Role;
using Promeetec.EDMS.Domain.Models.Identity.Users;
using Promeetec.EDMS.Domain.Models.Shared;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker;

public class Medewerker : IdentityUser<Guid>, IAggregateRoot
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
    /// <item>
    /// <description>Verwijderd: Medewerker is soft deleted.</description>
    /// </item>
    /// </list>
    /// </summary>
    public Status Status { get; set; }


    /// <summary>
    /// The type of medewerker.
    /// Can be either internal or external.
    /// </summary>
    public MedewerkerSoort MedewerkerSoort { get; set; }


    /// <summary>
    /// The persoon details.
    /// </summary>
    public virtual Persoon.Persoon Persoon { get; set; }


    /// <summary>
    /// The Vektis agbcode zorgverlener for the medewerker.
    /// </summary>
    [MaxLength(200)]
    public string AgbCodeZorgverlener { get; set; }


    /// <summary>
    /// The Vektis agbcode onderneming for the medewerker.
    /// </summary>
    [MaxLength(200)]
    public string AgbCodeOnderneming { get; set; }


    /// <summary>
    /// The job title  for the medewerker.
    /// </summary>
    [MaxLength(200)]
    public string Functie { get; set; }


    /// <summary>
    /// The avatar  for the medewerker.
    /// </summary>
    [MaxLength]
    [Column(TypeName = "varbinary(max)")]
    public byte[] Avatar { get; set; }


    /// <summary>
    /// The suspension reason for the medewerker.
    /// </summary>
    [MaxLength(450)]
    public string DeactivatieReden { get; set; }


    /// <summary>
    /// The ION toestemmingsverklaring activation link for this medewerker.
    /// </summary>
    public string IONToestemmingsverklaringActivatieLink { get; set; }


    /// <summary>
    /// The time stamp of the last login for this user.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? LaatstIngelogdOp { get; set; }


    /// <summary>
    /// The time stamp of the previous login for this user.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? VorigeLoginOp { get; set; }


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
    public UserAccountState AccountState { get; set; }


    /// <summary>
    /// Value indicating if Google authenticator is enabled for this medewerker.
    /// </summary>
    public bool GoogleAuthenticatorEnabled { get; set; }


    /// <summary>
    /// The Google authenticator secret key for this medewerker.
    /// </summary>
    [MaxLength(200)]
    public string GoogleAuthenticatorSecretKey { get; set; }


    /// <summary>
    /// The temporary password for this medewerker.
    /// </summary>
    [MaxLength(200)]
    public string TempCode { get; set; }


    /// <summary>
    /// The PUK-code for this medewerker.
    /// </summary>
    [MaxLength(200)]
    public string PukCode { get; set; }


    /// <summary>
    /// Value indicating if the activation email has been send.
    /// </summary>
    public bool ActivationMailSend { get; set; }


    /// <summary>
    /// The time stamp of when the activation email has been send.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? ActivationMailSendOn { get; set; }

    ///// <summary>
    ///// The unique identifier of the medewerker who sended the activation email.
    ///// </summary>
    //public Guid? ActivationMailSendById { get; set; }


    ///// <summary>
    ///// The name of the medewerker who sended the activation email.
    ///// </summary>
    //[MaxLength(200)]
    //public string ActivationMailSendBy { get; set; }



    /// <summary>
    /// The time stamp of when the record has been created.
    /// </summary>
    public DateTime TimeStamp { get; set; }

    /// <summary>
    /// The unique identifier of the creator of the medewerker.
    /// </summary>
    public Guid? CreatedById { get; set; }


    /// <summary>
    /// The name of the creator of the medewerker.
    /// </summary>
    public string CreatedBy { get; set; }


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


    #region Navigation properties

    /// <summary>
    /// The unique identifier of the medewerker who sended the activation email.
    /// </summary>
    [ForeignKey("ActivationMailSendBy")]
    public Guid? ActivationMailSendById { get; set; }


    /// <summary>
    /// Reference to the medewerker who send the activation email.
    /// </summary>
    public Medewerker ActivationMailSendBy { get; set; }

    public Guid OrganisatieId { get; set; }
    public virtual Organisatie.Organisatie Organisatie { get; set; }
    
    public Guid? AdresId { get; set; }
    public virtual Adres.Adres Adres { get; set; }

    public virtual UserProfile.UserProfile UserProfile { get; set; }
    public virtual ICollection<GroupUser> Groups { get; set; }
    public virtual ICollection<UserRole> Roles { get; set; }
    public virtual ICollection<VerzekerdeToUser> Verzekerden { get; set; }
    public virtual ICollection<Memo.Memo> Memos { get; set; }
    public virtual ICollection<UserClaim> Claims { get; set; }
    public virtual ICollection<UserLogin> Logins { get; set; }
    public virtual ICollection<UserToken> Tokens { get; set; }
    public virtual ICollection<UserRole> UserRoles { get; set; }
    public virtual ICollection<Event.Event> Events { get; set; }


    #endregion


    /// <summary>
    /// Creates an empty user.
    /// </summary>
    public Medewerker()
    {
        Id = Guid.NewGuid();
    }

    public Medewerker(Guid id) : this()
    {
        if (id == Guid.Empty)
            id = Guid.NewGuid();

        Id = id;
    }

    #region AggregateRoot implementations

    public override Guid Id { get; set; }

    #endregion
}
