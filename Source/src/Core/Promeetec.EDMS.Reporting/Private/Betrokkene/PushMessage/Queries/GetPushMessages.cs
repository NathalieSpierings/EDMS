using Promeetec.EDMS.Queries;
using Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Queries;

public class GetPushMessages : IQuery<PushMessagesViewModel>
{
    public string SearchTerm { get; set; }
}