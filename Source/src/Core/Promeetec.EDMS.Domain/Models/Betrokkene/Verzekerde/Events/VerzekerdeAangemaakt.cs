using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Events
{
    public class VerzekerdeAangemaakt : EventBase
    {
        public string Status { get; set; }

        public string Bsn { get; set; }
        public string Geslacht { get; set; }
        public string? Geboortedatum { get; set; }
        public string VolledigeNaam { get; set; }
        public string AgbcodeVerwijzer { get; set; }
        public string NaamVerwijzer { get; set; }
        public string? Adres { get; set; }
        public string? Verwijsdatum { get; set; }
        public string? PatientNummer { get; set; }
        public string? VerzekerdeNummer { get; set; }
        public string VerzekerdOp { get; set; }
        public string? VerzekerdTot { get; set; }
        public string Uzovi { get; set; }
        public string NaamVerzekeraar { get; set; }
        public string ProfielCode { get; set; }
        public string ProfielStartdatum { get; set; }
        public string? ProfielEinddatum { get; set; }
    }
}