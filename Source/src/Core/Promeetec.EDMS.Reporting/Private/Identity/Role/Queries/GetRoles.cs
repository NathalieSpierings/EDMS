using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Identity.Role.Models;

namespace Promeetec.EDMS.Reporting.Private.Identity.Role.Queries;

public class GetRoles : IQuery<RolesViewModel>
{
    public string SearchTerm { get; set; }
}