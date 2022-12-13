using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Identity.Role.Commands;

public class CreateRole : CommandBase
{
    public string Name { get; set; }
    public string Description { get; set; }
}