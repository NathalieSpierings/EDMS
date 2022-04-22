using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Identity.Group;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;

public class AddMedewerkerToGroup : CommandBase
{
    public GroupUser GroupUser { get; set; }
}
