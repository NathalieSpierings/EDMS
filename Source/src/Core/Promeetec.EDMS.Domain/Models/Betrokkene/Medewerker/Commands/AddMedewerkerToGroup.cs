using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Identity.Group;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker.Commands;

public class AddMedewerkerToGroup : CommandBase
{
    public GroupUser GroupUser { get; set; }
}
