using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Events;

public class VerzekerdeMetZorgprofielGeactiveerd : EventBase
{
    public string Status { get; set; }
    public string ProfielCode { get; set; }
    public string ProfielStartdatum { get; set; }
    public string ProfielEinddatum { get; set; }
}