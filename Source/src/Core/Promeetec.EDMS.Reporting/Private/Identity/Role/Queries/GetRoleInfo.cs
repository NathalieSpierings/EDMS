using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Identity.Role.Models;

namespace Promeetec.EDMS.Reporting.Private.Identity.Role.Queries;

public class GetRole : IQuery<RoleViewModel>
{
    public Guid RoleId { get; set; }
}