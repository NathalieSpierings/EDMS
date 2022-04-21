using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;

public class DeleteOrganisatie : CommandBase
{
    public Guid DeleteOrganisatieId = Guid.NewGuid();

}
