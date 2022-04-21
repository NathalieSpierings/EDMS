namespace Promeetec.EDMS.Domain.Document.Bestand.Commands
{
    public class WijzigBestand : DomainCommand<Bestand>
    {
        public Guid OrganisatieId { get; set; }
        public DateTime? AangepastOp { get; set; }
        public Guid? AangepastDoor { get; set; }
        public Guid EigenaarId { get; set; }
        public string FileName { get; set; }
    }
}