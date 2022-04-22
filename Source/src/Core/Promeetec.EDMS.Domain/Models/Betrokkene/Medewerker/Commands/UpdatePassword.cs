using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;

public class UpdatePassword : CommandBase
{
    public string Password { get; set; }
}
