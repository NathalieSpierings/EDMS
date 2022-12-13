using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Identity.Group.Commands;

public class UpdateGroup : CommandBase
{
    public string Name { get; set; }
    public string Description { get; set; }
}