namespace Promeetec.EDMS.Domain.Document.Aanleverbestand.Aanleverberstand.Events
{
    public class AanleverbestandWorkflowStateGewijzigd : DomainEvent
    {
        public string WorkFlowState { get; set; }
        public Guid? VoorraadId { get; set; }
        public Guid? AanleveringId { get; set; }
    }
}