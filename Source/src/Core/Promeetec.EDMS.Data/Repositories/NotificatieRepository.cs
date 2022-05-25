using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Betrokkene.Notification;

namespace Promeetec.EDMS.Data.Repositories;

public class NotificatieRepository : Repository<Notificatie>, INotificatieRepository
{
    public NotificatieRepository(EDMSDbContext context)
        : base(context)
    {
    }

}