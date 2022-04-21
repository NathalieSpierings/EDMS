namespace Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Commands
{
    public class UpdateVerzekerdeLengte : DomainCommand<Verzekerde>
    {
        public double Lengte { get; set; }
    }
}