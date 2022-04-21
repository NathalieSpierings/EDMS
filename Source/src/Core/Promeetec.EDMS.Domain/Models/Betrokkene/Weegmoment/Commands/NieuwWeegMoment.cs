namespace Promeetec.EDMS.Domain.Betrokkene.Weegmoment.Commands
{
    public class NieuwWeegMoment : DomainCommand<Weegmoment>
    {
        public double Lengte { get; set; }
        public double Gewicht { get; set; }
        public DateTime Opnamedatum { get; set; }
        public Guid VerzekerdeId { get; set; }
    }
}