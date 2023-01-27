using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Commands;

public class LoginMedewerker : CommandBase
{
    public DateTime? IngelogdOp { get; set; }
    public DateTime? VorigeLoginOp { get; set; }
    public string UserHostAddress { get; set; }
    public string UserAgent { get; set; }
}
