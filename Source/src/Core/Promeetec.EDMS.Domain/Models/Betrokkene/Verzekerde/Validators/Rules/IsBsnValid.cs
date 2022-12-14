using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Validators.Rules;

public class IsBsnValid : QueryBase<bool>
{
    public string Bsn { get; set; }
}
