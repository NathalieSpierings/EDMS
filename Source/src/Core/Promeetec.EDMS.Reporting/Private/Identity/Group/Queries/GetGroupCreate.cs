using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Identity.Group.Models;

namespace Promeetec.EDMS.Reporting.Private.Identity.Group.Queries;

public class GetGroupCreate : IQuery<GroupCreateViewModel>
{
    public Guid GroupId { get; set; }
}