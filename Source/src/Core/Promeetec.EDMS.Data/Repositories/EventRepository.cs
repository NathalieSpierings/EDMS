using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Event;

namespace Promeetec.EDMS.Data.Repositories;

public class EventRepository : Repository<Event>, IEventRepository
{
    public EventRepository(EDMSDbContext context)
        : base(context)
    {
    }

}