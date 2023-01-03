using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Queries;

public class GetPushMessage : IQuery<PushMessageViewModel>
{
    public Guid PushMessageId { get; set; }

}