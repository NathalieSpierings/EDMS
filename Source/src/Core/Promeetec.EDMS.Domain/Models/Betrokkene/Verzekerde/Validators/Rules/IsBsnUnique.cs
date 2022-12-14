using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Validators.Rules;

public class IsBsnUnique : QueryBase<bool>
{
    public Guid AdresboekId { get; set; }
    public string Bsn { get; set; }
}
