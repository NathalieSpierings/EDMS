using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Notification;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class NotificatieRepository : Repository<Notificatie>, INotificatieRepository
{
    public NotificatieRepository(EDMSDbContext context)
        : base(context)
    {
    }

}