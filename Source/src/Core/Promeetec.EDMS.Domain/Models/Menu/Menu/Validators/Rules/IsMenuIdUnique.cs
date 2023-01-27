using Promeetec.EDMS.Portaal.Core.Queries;

namespace Promeetec.EDMS.Portaal.Domain.Models.Menu.Menu.Validators.Rules;

public class IsMenuIdUnique : QueryBase<bool>
{
    public Guid? Id { get; set; }
}
