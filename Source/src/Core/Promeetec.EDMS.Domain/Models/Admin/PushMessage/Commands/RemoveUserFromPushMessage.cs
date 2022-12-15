using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Admin.PushMessage.Commands;

public class RemoveUserFromPushMessage : CommandBase
{
    public Guid MedewerkerId { get; set; }
    public Guid PushMessageId { get; set; }

}