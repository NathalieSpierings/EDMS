namespace Promeetec.EDMS.Domain.Betrokkene.Weegmoment.Events
{
    public class WeegMomentToegevoegd : DomainEvent
    {
        public string Lengte { get; set; }
        public string Gewicht { get; set; }
        public string Opnamedatum { get; set; }
    }
}