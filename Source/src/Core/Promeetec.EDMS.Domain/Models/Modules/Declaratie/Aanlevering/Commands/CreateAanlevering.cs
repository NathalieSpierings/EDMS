namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanlevering.Commands
{
    public class CreateAanlevering : DomainCommand<Aanlevering>
    {
        public string Organisatie { get; set; }
        public string Behandelaar { get; set; }
        public string Eigenaar { get; set; }
        public string Referentie { get; set; }
        public string ReferentiePromeetec { get; set; }
        public bool ToevoegenBestand { get; set; }
        public string Opmerking { get; set; }
        public Guid OrganisatieId { get; set; }
        public Guid? BehandelaarId { get; set; }
        public Guid EigenaarId { get; set; }
    }
}