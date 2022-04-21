using Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Zorgprofiel;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;

public class VerzekerdeToZorgprofiel
{
    public Guid ZorgprofielId { get; set; }
    public virtual Zorgprofiel Zorgprofiel { get; set; }

    public Guid VerzekerdeId { get; set; }
    public virtual Verzekerde Verzekerde { get; set; }
}
