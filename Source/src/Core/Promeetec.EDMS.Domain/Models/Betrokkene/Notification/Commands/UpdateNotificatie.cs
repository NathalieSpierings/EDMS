namespace Promeetec.EDMS.Domain.Betrokkene.Notification.Commands;

public class UpdateNotificatie : DomainCommand<Notificatie>
{
    public NotificatieStatus NotificatieStatus { get; set; }
}