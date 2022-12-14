using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Modules.GLI.Behandelplan.Validators.Rules;

public class IsEinddatumValid : QueryBase<bool>
{
    public DateTime Einddatum { get; set; }
}
