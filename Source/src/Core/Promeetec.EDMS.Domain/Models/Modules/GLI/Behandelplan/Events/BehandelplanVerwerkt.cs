namespace Promeetec.EDMS.Domain.Modules.GLI.Behandelplan.Events
{
    public class BehandelplanVerwerkt : DomainEvent
    {
        public string Verwerkt { get; set; }
        public string VerwerktOp { get; set; }
        public string Status { get; set; }
    }
}