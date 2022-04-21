using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;

public class RestrictOrganisatie : CommandBase
{
    public Guid RestrictOrganisatieId = Guid.NewGuid();

    public string Reason { get; set; }
}
