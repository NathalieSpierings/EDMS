namespace Promeetec.EDMS.Portaal.Core.Events;

public interface IEvent
{
    public Guid Id { get; set; }
    public Guid TargetId { get; set; }
    public string TargetType { get; set; }
    public Guid OrganisatieId { get; set; }
    public Guid? UserId { get; set; }
    public DateTime TimeStamp { get; set; }
}
