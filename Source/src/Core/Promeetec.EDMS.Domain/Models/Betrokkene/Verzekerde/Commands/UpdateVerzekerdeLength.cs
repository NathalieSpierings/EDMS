using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Commands
{
    public class UpdateVerzekerdeLength : CommandBase
    {
        public double Lengte { get; set; }
    }
}