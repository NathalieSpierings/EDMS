namespace Promeetec.EDMS.Domain.Document.Bestand.Events
{
    public class BestandGewijzigd : DomainEvent
    {
        public DateTime? AangepastOp { get; set; }
        public Guid? AangepastDoor { get; set; }
        public Guid EigenaarId { get; set; }
        public string FileName { get; set; }
    }
}