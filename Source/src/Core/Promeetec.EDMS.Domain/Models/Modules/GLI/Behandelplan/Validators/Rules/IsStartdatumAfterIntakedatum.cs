using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Modules.GLI.Behandelplan.Validators.Rules;

public class IsStartdatumAfterIntakedatum : QueryBase<bool>
{
    public DateTime Intakedatum { get; set; }
    public DateTime Startdatum { get; set; }
}
