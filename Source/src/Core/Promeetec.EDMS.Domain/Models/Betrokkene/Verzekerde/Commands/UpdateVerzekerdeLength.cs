using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Commands
{
    public class UpdateVerzekerdeLength : CommandBase
    {
        public double Lengte { get; set; }
    }
}