using OpenCqrs.Domain;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Promeetec.EDMS.Domain.Domain.Betrokkene.Notification;

public class Notificatie : AggregateRoot
{
    /// <summary>
    /// The title of the notification.
    /// </summary>
    [Required]
    [StringLength(450)]
    public string Titel { get; set; }

    /// <summary>
    /// The message of the notification.
    /// </summary>
    [Required]
    [MaxLength]
    public string Bericht { get; set; }


    /// <summary>
    /// The url for the notification.
    /// </summary>
    [StringLength(450)]
    public string Url { get; set; }

    /// <summary>
    /// The type of notification.
    /// <list type="bullet">
    /// <item>
    /// <description>Algemeen:  A generic notification.</description>
    /// </item>
    /// <item>
    /// <description>Bericht:  A notification about a message.</description>
    /// </item>
    /// <item>
    /// <description>Document:  A notification about an documument.</description>
    /// </item>
    /// <item>
    /// <description>Aanleverstatus:  A notification about a aanleverstatus.</description>
    /// </item>
    /// <item>
    /// <description>Rapportage: A notification about a rapportage.</description>
    /// </item>
    /// </list>
    /// </summary>
    public NotificatieType NotificatieType { get; set; }


    /// <summary>
    /// The date of the notification.
    /// </summary>
    [Required]
    [Column(TypeName = "datetime2")]
    public DateTime Datum { get; set; }


    /// <summary>
    /// The status of the notification.
    /// <list type="bullet">
    /// <item>
    /// <description>Nieuw: A new notification.</description>
    /// </item>
    /// <item>
    /// <description>Gelezen: An readed notification.</description>
    /// </item>
    /// </list>
    /// </summary>
    public NotificatieStatus NotificatieStatus { get; set; }

    /// <summary>
    /// The date the notification has been readed.
    /// </summary>
    [Column(TypeName = "datetime2")]
    public DateTime? GelezenOp { get; set; }



    #region Navigation Properties

    /// <summary>
    /// The unique identifier of the medewerker for the notification.
    /// </summary>
    public Guid MedewerkerId { get; set; }

    /// <summary>
    /// Reference to the medewerker for the notification.
    /// </summary>
    public Medewerker.Medewerker Medewerker { get; set; }

    #endregion

    public Notificatie() { }

}
