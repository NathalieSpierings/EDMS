using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Commands;

public class SuspendMedewerker : CommandBase
{
    public string DeactivatieReden { get; set; }
}
