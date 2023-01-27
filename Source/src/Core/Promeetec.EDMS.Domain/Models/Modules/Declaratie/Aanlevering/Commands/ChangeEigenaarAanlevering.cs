using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Commands;

public class ChangeEigenaarAanlevering : CommandBase
{
    public string EigenaarVolledigeNaam { get; set; }
    public Guid EigenaarId { get; set; }
}