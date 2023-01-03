using System;
using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Queries;

public class GetPushMessageCreateEdit : IQuery<PushMessageCreateViewModel>
{
    public Guid PushMessageId { get; set; }
}