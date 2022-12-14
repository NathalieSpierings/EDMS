using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Modules.GLI.Behandelplan.Validators.Rules;

public class IsStartdatumValid : QueryBase<bool>
{
    public DateTime Startdatum { get; set; }
}
