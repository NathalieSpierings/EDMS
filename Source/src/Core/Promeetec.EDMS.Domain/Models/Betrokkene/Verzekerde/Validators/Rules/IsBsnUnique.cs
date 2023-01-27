using Promeetec.EDMS.Portaal.Core.Queries;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Validators.Rules;

public class IsBsnUnique : QueryBase<bool>
{
    public Guid AdresboekId { get; set; }
    public string Bsn { get; set; }
}
