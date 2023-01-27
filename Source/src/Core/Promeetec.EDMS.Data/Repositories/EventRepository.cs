using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Event;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class EventRepository : Repository<Event>, IEventRepository
{
    public EventRepository(EDMSDbContext context)
        : base(context)
    {
    }

}