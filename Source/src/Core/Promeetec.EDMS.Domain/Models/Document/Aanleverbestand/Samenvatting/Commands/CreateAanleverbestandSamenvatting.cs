﻿namespace Promeetec.EDMS.Domain.Document.Aanleverbestand.Samenvatting.Commands
{
    public class CreateAanleverbestandSamenvatting : DomainCommand<Aanleverberstand.Aanleverbestand>
    {
        public string EiStandaard { get; set; }
        public int? AantalVerzekerdeRecords { get; set; }
        public int? AantalPrestatieRecords { get; set; }
        public decimal? TotaalDeclaratiebedrag { get; set; }
        public int? Zorgverlenerscode { get; set; }
        public int? Praktijkcode { get; set; }
        public int? Instellingscode { get; set; }
        public bool Processed { get; set; }
        public int OvergeslagenRows { get; set; }
        public Guid AanleverbestandId { get; set; }
    }
}