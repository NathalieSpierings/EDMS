using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.Declaratie.Aanlevering.Commands;

public class ChangeEigenaarAanlevering : CommandBase
{
    public string EigenaarVolledigeNaam { get; set; }
    public Guid EigenaarId { get; set; }
}