using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;

public class SuspendMedewerker : CommandBase
{
    public string DeactivatieReden { get; set; }
}
