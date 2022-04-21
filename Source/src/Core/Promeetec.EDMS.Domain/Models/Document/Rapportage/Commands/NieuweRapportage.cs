namespace Promeetec.EDMS.Domain.Document.Rapportage.Commands
{
    public class NieuweRapportage : DomainCommand<Rapportage>
    {
        public Guid OrganisatieId { get; set; }
        public string FileName { get; set; }
        public string MimeType { get; set; }
        public string Extension { get; set; }
        public int FileSize { get; set; }
        public byte[] Data { get; set; }
        public string ReferentiePromeetec { get; set; }
        public Guid EigenaarId { get; set; }
        public string Eigenaar { get; set; }
        public string Organisatie { get; set; }
        public RapportageSoort RapportageSoort { get; set; }
    }
}