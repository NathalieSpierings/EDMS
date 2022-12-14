using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Modules.GLI.Intake.Validators.Rules;

public class IsIntakedatumValid : QueryBase<bool>
{
    public DateTime Intakedatum { get; set; }
}
