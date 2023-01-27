using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanlevering.Commands;

public class DeleteAanlevering : CommandBase
{
    public Shared.Status Status { get; set; }
}