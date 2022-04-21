namespace Promeetec.EDMS.Domain.Document.Aanleverbestand.Aanleverberstand.Commands
{
    public class WijzigAanleverbestand : DomainCommand<Aanleverbestand>
    {
        public string Periode { get; set; }
        public AanleverbestandWorkflowState WorkFlowState { get; set; }
        public Guid? ZorgstraatId { get; set; }
        public string Zorgstraat { get; set; }
        public Guid? VoorraadId { get; set; }
        public Guid? AanleveringId { get; set; }
        public Guid EigenaarId { get; set; }
        public string Eigenaar { get; set; }
        public DateTime? AangepastOp { get; set; }
        public Guid? AangepastDoor { get; set; }
    }
}