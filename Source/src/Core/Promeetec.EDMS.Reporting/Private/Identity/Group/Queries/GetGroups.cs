using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Identity.Group.Models;

namespace Promeetec.EDMS.Reporting.Private.Identity.Group.Queries;

public class GetGroups : IQuery<GroupsViewModel>
{
    public string SearchTerm { get; set; }
}