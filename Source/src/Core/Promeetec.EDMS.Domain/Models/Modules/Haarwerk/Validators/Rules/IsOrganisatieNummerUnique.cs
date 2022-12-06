using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Validators.Rules;

public class IsOrganisatieNummerUnique : QueryBase<bool>
{
    public string Nummer { get; set; }
    public Guid? Id { get; set; }
}
