using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Organisatie.Rules;

public class IsOrganisatieNummerUnique : QueryBase<bool>
{
    public string Nummer { get; set; }
    public Guid? Id { get; set; }
}
