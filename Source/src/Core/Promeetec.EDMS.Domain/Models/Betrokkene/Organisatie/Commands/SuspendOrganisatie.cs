using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;

public class SuspendOrganisatie : CommandBase
{
    public Guid SuspendOrganisatieId = Guid.NewGuid();

}
