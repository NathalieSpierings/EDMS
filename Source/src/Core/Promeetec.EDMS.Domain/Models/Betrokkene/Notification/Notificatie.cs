using System.ComponentModel.DataAnnotations;
using Promeetec.EDMS.Domain.Models.Betrokkene.Notification.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Notification;

public class Notificatie : AggregateRoot
{
    /// <summary>
    /// The title of the notification.
    /// </summary>
    [Required, MaxLength(256)]
    public string Titel { get; set; }

    /// <summary>
    /// The message of the notification.
    /// </summary>
    [Required, MaxLength(450)]
    public string Bericht { get; set; }


    /// <summary>
    /// The url for the notification.
    /// </summary>
    [MaxLength(256)]
    public string? Url { get; set; }

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
    public DateTime? GelezenOp { get; set; }


    #region Navigation Properties

    public Guid MedewerkerId { get; set; }
    public virtual Medewerker.Medewerker Medewerker { get; set; }

    #endregion


    /// <summary>
    /// Creates an empty notificatie.
    /// </summary>
    public Notificatie()
    {

    }

    /// <summary>
    /// Creates a notification.
    /// </summary>
    /// <param name="cmd">The create notification command.</param>
    public Notificatie(CreateNotificatie cmd)
    {
        Id = cmd.Id;
        Datum = DateTime.Now;
        Titel = cmd.Titel;
        Bericht = cmd.Bericht;
        Url = cmd.Url;
        NotificatieType = cmd.NotificatieType;
        NotificatieStatus = NotificatieStatus.Nieuw;
        MedewerkerId = cmd.OntvangerId;
    }

    /// <summary>
    /// Updates a notification.
    /// </summary>
    /// <param name="cmd">The update notification command.</param>
    public void Update(UpdateNotificatie cmd)
    {
        GelezenOp = cmd.NotificatieStatus == NotificatieStatus.Nieuw ? (DateTime?)null : DateTime.Now;
        NotificatieStatus = cmd.NotificatieStatus;
    }
}
