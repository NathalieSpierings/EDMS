using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.PushMessage.Commands;

public class RemoveUserFromPushMessage : CommandBase
{
    public Guid MedewerkerId { get; set; }
    public Guid PushMessageId { get; set; }

}