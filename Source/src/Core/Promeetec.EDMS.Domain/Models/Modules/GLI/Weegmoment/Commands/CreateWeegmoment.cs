using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.GLI.Weegmoment.Commands
{
    public class CreateWeegmoment : CommandBase
    {
        public double Lengte { get; set; }
        public double Gewicht { get; set; }
        public DateTime Opnamedatum { get; set; }
        public Guid VerzekerdeId { get; set; }
    }
}