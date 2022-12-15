using Promeetec.EDMS.Domain.Models.Admin.PushMessage.Commands;

namespace Promeetec.EDMS.Domain.Models.Admin.PushMessage;

public class PushMessageToUser
{
    public Guid UserId { get; set; }
    public virtual Betrokkene.Medewerker.Medewerker User { get; set; }

    public Guid MessageId { get; set; }
    public virtual Admin.PushMessage.PushMessage Message { get; set; }

    public bool Read { get; set; }
    public DateTime? ReadedOn { get; set; }


    public void RemoveUser(RemoveUserFromPushMessage cmd)
    {
    }
}