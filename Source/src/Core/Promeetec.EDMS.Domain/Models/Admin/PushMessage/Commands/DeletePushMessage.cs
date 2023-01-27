using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.PushMessage.Commands;

public class DeletePushMessage : CommandBase
{
    public Guid PushMessageId { get; set; }
}