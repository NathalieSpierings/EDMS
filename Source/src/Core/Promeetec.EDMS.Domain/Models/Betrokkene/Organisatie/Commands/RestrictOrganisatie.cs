using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Commands;

public class RestrictOrganisatie : CommandBase
{
    public string Reason { get; set; }
}
