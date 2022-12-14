using Promeetec.EDMS.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.Verbruiksmiddelen.Verbruiksmiddel.Commands;

public class ProcessVerbruiksmiddelPrestatie : CommandBase
{
    public VerbruiksmiddelPrestatieStatus Status { get; set; }
}