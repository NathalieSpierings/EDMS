using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Memo.Events;

public class MemoAangemaakt : EventBase
{
    public string Datum { get; set; }
    public string Memo { get; set; }
}