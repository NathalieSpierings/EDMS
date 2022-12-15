using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Data.Context;
using Promeetec.EDMS.Domain.Models.Admin.PushMessage;

namespace Promeetec.EDMS.Data.Repositories;

public class PushMessageRepository : Repository<PushMessage>, IPushMessageRepository
{
    public PushMessageRepository(EDMSDbContext context)
        : base(context)
    {
    }

    public async Task<PushMessage?> GetByIdWithUsersAsync(Guid messageId)
    {
        var message = await Query()
            .Include(i => i.Users)
            .Where(x => x.Id == messageId).FirstOrDefaultAsync();

        return message;
    }
}