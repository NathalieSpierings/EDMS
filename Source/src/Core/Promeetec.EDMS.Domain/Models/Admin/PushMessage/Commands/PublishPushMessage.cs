using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Admin.PushMessage.Commands;

public class PublishPushMessage : CommandBase
{
    public Guid PushMessageId { get; set; }
}