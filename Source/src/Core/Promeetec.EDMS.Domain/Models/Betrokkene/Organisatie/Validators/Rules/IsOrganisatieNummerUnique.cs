using Promeetec.EDMS.Portaal.Core.Queries;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Organisatie.Validators.Rules;

public class IsOrganisatieNummerUnique : QueryBase<bool>
{
    public string Nummer { get; set; }
    public Guid? Id { get; set; }
}
