using Promeetec.EDMS.Portaal.Core.Domain;
using Promeetec.EDMS.Portaal.Domain.Models.Betrokkene.Medewerker;

namespace Promeetec.EDMS.Portaal.Domain.Models.Event;

public class Event: AggregateRoot
{
    public DateTime TimeStamp { get; set; } = DateTime.UtcNow;

    public string Type { get; set; }
    public string Data { get; set; }

    public Guid TargetId { get; set; }
    public string TargetType { get; set; }

   
    #region Navigation propertiees

    public Guid OrganisatieId { get; set; }
    
    public Guid? UserId { get; set; }
    public virtual Medewerker User { get; set; }

    #endregion
}