using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Notification.Commands;

public class UpdateNotificatie : CommandBase
{
    public NotificatieStatus NotificatieStatus { get; set; }
}