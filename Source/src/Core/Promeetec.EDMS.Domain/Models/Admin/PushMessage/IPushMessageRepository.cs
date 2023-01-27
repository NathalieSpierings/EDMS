using Promeetec.EDMS.Portaal.Core.Domain;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.PushMessage;

public interface IPushMessageRepository : IRepository<PushMessage>
{
    Task<PushMessage?> GetPushmessageByIdAsync(Guid messageId);
}