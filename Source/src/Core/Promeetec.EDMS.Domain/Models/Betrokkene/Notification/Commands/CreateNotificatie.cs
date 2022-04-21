namespace Promeetec.EDMS.Domain.Betrokkene.Notification.Commands;

public class CreateNotificatie : DomainCommand<Notificatie>
{
    public string Titel { get; set; }
    public string Bericht { get; set; }
    public string Url { get; set; }
    public int Volgorde { get; set; }
    public NotificatieType NotificatieType { get; set; }
    public NotificatieStatus NotificatieStatus { get; set; }
    public DateTime Datum { get; set; }
    public bool Gelezen { get; set; }
    public DateTime? GelezenOp { get; set; }
    public Guid OntvangerId { get; set; }
}