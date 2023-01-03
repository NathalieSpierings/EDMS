using Promeetec.EDMS.Reporting.Shared.Models;

namespace Promeetec.EDMS.Reporting.Private.Admin.Prullenbak.Models;

public class PrullenbakListItemViewModel : ModelBase
{
    public PrullenbakSoort Soort { get; set; }
    public string Naam { get; set; }
    public Guid? VerwijderdDoorId { get; set; }
    public string VerwijderdDoor { get; set; }
    public DateTime? VerwijderdOp { get; set; }
}