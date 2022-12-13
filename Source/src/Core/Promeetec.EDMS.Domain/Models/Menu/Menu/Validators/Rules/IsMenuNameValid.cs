using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Menu.Menu.Validators.Rules;

public class IsMenuNameValid : QueryBase<bool>
{
    public string Name { get; set; }
}
