using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Notification.Commands;

public class UpdateNotificatie : CommandBase
{
    public NotificatieStatus NotificatieStatus { get; set; }
}