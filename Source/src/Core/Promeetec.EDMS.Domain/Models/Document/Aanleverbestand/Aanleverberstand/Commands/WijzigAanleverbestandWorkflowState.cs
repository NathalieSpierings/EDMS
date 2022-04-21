namespace Promeetec.EDMS.Domain.Document.Aanleverbestand.Aanleverberstand.Commands
{
    public class WijzigAanleverbestandWorkflowState : DomainCommand<Aanleverbestand>
    {
        public AanleverbestandWorkflowState WorkFlowState { get; set; }
        public Guid? VoorraadId { get; set; }
        public Guid? AanleveringId { get; set; }
        public DateTime? AangepastOp { get; set; }
        public Guid? AangepastDoor { get; set; }
    }
}