using Promeetec.EDMS.Domain.Domain.Modules.Verbruiksmiddelen.Zorgprofiel;

namespace Promeetec.EDMS.Domain.Domain.Betrokkene.Verzekerde;

public class VerzekerdeToZorgprofiel
{
    public Guid ZorgprofielId { get; set; }
    public virtual Zorgprofiel Zorgprofiel { get; set; }

    public Guid VerzekerdeId { get; set; }
    public virtual Verzekerde Verzekerde { get; set; }
}
