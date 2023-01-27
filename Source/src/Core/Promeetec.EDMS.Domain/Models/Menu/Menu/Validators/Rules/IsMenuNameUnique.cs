using Promeetec.EDMS.Portaal.Core.Queries;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Validators.Rules;

public class IsMenuNameUnique : QueryBase<bool>
{
    public string Name { get; set; }
}
