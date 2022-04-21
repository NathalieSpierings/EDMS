using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;

public class ReinstateOrganisatie : CommandBase
{
    public Guid ReinstateOrganisatieId = Guid.NewGuid();

}
