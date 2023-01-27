namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI
{
    public class GliDto
    {
        public Guid OrganisatieId { get; set; }
        public string OrganisatieNummer { get; set; }
        public string OrganisatieNaam { get; set; }
        public string BehandelaarVolledigeNaam { get; set; }
        public string Bsn { get; set; }
        public string Geslacht { get; set; }
        public DateTime? Geboortedatum { get; set; }
        public string Voorletters { get; set; }
        public string? Tussenvoegsel { get; set; }
        public string Achternaam { get; set; }
        public string AgbCodeVerwijzer { get; set; }
        public string NaamVerwijzer { get; set; }
        public short Uzovi { get; set; }
        public Guid? IntakeId { get; set; }
        public DateTime? IntakeDatum { get; set; }
        public string? IntakeOpmerking { get; set; }
        public Guid BehandelplanId { get; set; }
        public string Fase { get; set; }
        public DateTime? StartdatumBehandelplan { get; set; }
        public DateTime? EinddatumBehandelplan { get; set; }
        public string GliProgramma { get; set; }
        public string OpmerkingBehandelplan { get; set; }
        public string GliStatus { get; set; }
        public bool VoortijdigGestopt { get; set; }
        public DateTime? VoortijdigeStopdatum { get; set; }
        public string CodeRedenEindeZorg { get; set; }
        public string OmschrijvingRedenEindeZorg { get; set; }
        public DateTime AangemaaktOp { get; set; }
    }
}