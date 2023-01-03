using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Queries;

public class GetUserPushMessage : IQuery<UserPushMessageViewModel>
{
    public Guid UserId { get; set; }
}