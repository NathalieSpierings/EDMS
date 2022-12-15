namespace Promeetec.EDMS.Domain.Models.Admin.PushMessage;

public interface IPushMessageRepository : IRepository<PushMessage>
{
    Task<PushMessage?> GetByIdWithUsersAsync(Guid messageId);
}