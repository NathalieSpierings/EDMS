using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Data.Context;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.PushMessage;

namespace Promeetec.EDMS.Portaal.Data.Repositories;

public class PushMessageRepository : Repository<PushMessage>, IPushMessageRepository
{
    public PushMessageRepository(EDMSDbContext context)
        : base(context)
    {
    }

    public async Task<PushMessage?> GetPushmessageByIdAsync(Guid messageId)
    {
        var message = await Query()
            .Include(i => i.Users)
            .Where(x => x.Id == messageId).FirstOrDefaultAsync();

        return message;
    }
}