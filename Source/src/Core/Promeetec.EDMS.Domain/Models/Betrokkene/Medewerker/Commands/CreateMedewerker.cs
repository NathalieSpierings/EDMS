using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;

public class CreateMedewerker : CommandBase
{
    public Guid CreateMedewerkerId = Guid.NewGuid();

}
