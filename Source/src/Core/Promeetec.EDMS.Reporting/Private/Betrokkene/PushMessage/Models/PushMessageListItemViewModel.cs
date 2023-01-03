using System;
using Promeetec.EDMS.Domain.Models.Betrokkene.PushMessage;
using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Betrokkene.PushMessage.Models;

public class PushMessageListItemViewModel : ModelBase
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public DateTime Date { get; set; }
    public PushMessageStatus Status { get; set; }
}
