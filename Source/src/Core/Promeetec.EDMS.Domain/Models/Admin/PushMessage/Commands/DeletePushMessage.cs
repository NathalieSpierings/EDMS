using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Admin.PushMessage.Commands;

public class DeletePushMessage : CommandBase
{
    public Guid PushMessageId { get; set; }
}