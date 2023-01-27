using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Identity.Group.Commands;

public class UpdateGroup : CommandBase
{
    public string Name { get; set; }
    public string Description { get; set; }
}