namespace Promeetec.EDMS.Domain.Betrokkene.Verzekeraar.Commands
{
    public class CreateVerzekeraar : DomainCommand<Verzekeraar>
    {
        public short Uzovi { get; set; }
        public string Naam { get; set; }
        public bool Actief { get; set; }
    }
}