namespace Promeetec.EDMS.Events;

public abstract class EventBase : IEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid TargetId { get; set; }
    public string TargetType { get; set; }
    public Guid OrganisatieId { get; set; }
    public string OrganisatieDisplayName { get; set; }

    public Guid? UserId { get; set; }
    public string UserDisplayName { get; set; }
    public DateTime TimeStamp { get; set; } = DateTime.Now;

    public bool ShouldSerializeId() => false;
    public bool ShouldSerializeTargetId() => false;
    public bool ShouldSerializeTargetType() => false;
    public bool ShouldSerializeOrganisatieId() => false;
    public bool ShouldSerializeUserId() => false;
    public bool ShouldSerializeTimeStamp() => false;
}