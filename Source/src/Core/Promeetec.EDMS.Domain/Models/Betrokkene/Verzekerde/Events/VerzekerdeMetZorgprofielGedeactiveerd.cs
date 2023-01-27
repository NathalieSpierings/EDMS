using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Verzekerde.Events;

public class VerzekerdeMetZorgprofielGedeactiveerd : EventBase
{
    public string Status { get; set; }
    public string ProfielCode { get; set; }
    public string ProfielStartdatum { get; set; }
    public string ProfielEinddatum { get; set; }
}