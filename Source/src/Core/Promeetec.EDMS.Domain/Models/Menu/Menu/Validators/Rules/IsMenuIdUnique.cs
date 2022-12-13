using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS.Domain.Models.Menu.Menu.Validators.Rules;

public class IsMenuIdUnique : QueryBase<bool>
{
    public Guid? Id { get; set; }
}
