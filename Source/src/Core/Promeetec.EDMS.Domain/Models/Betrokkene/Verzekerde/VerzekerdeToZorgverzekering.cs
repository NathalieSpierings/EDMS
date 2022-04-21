namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde;

public class VerzekerdeToZorgverzekering
{
    public Guid ZorgverzekeringId { get; set; }
    public virtual Zorgverzekering.Zorgverzekering Zorgverzekering { get; set; }

    public Guid VerzekerdeId { get; set; }
    public virtual Verzekerde Verzekerde { get; set; }
}
