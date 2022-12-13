using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Menu.Menu.Validators.Rules;

public class IsMenuNameUnique : QueryBase<bool>
{
    public string Name { get; set; }
}
