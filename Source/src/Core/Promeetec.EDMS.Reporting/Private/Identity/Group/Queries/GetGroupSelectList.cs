using Promeetec.EDMS.Domain.Models.Identity;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Identity.Group.Models;

namespace Promeetec.EDMS.Reporting.Private.Identity.Group.Queries;

public class GetGroupSelectList : IQuery<GroupSelectList>
{
    public UserPrincipal User { get; set; }
}