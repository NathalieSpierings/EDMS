using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Identity.Users;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Medewerker.Commands;

public class UpdateAccountState : CommandBase
{
    public UserAccountState AccountState { get; set; }
}
