using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Commands
{
    public class UpdateVerzekerdeLengte : CommandBase
    {
        public double Lengte { get; set; }
    }
}