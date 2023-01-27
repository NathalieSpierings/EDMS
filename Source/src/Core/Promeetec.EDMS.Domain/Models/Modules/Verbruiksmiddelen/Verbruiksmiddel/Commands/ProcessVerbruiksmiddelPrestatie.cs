using Promeetec.EDMS.Portaal.Core.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Commands;

public class ProcessVerbruiksmiddelPrestatie : CommandBase
{
    public VerbruiksmiddelPrestatieStatus Status { get; set; }
}