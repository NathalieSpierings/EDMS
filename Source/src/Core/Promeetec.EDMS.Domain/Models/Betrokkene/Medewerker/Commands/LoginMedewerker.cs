using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;

public class LoginMedewerker : CommandBase
{
    public DateTime? IngelogdOp { get; set; }
    public DateTime? VorigeLoginOp { get; set; }
    public string UserHostAddress { get; set; }
    public string UserAgent { get; set; }
}
