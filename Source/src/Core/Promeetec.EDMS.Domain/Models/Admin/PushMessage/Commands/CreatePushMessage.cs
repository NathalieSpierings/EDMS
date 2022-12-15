using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Identity.Group;

namespace Promeetec.EDMS.Domain.Models.Admin.PushMessage.Commands;

public class CreatePushMessage : CommandBase
{
    public string Title { get; set; }
    public string Message { get; set; }
    public DateTime Date { get; set; }
    public Guid? MedewerkerId { get; set; }
    public PushMessageStatus Status { get; set; }
    public List<Guid> SelectedGroupIds { get; set; }
    public IEnumerable<Group> Groups { get; set; }
}