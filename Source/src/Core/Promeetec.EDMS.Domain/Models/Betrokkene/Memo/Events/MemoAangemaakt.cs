using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Memo.Events;

public class MemoAangemaakt : EventBase
{
    public string Datum { get; set; }
    public string Memo { get; set; }
}