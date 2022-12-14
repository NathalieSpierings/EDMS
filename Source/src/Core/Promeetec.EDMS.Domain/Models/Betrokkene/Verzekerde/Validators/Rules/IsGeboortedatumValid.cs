using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Validators.Rules;

public class IsGeboortedatumValid : QueryBase<bool>
{
    public DateTime? Geboortedatum { get; set; }
}
