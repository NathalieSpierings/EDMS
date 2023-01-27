using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Commands;

public class RestrictOrganisatie : CommandBase
{
    public string Reason { get; set; }
}
