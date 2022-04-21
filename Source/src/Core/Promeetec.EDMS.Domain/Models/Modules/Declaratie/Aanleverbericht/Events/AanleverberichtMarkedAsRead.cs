namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanleverbericht.Events
{
    public class AanleverberichtMarkedAsRead : DomainEvent
    {
        public bool Read { get; set; }
        public DateTime? LaastGelezenOp { get; set; }
        public Guid LaasteLezerId { get; set; }
    }
}
