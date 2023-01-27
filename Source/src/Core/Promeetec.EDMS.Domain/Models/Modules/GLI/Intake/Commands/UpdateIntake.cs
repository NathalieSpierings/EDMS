using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Weegmoment.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Commands;

public class UpdateIntake : CommandBase
{
    public DateTime IntakeDatum { get; set; }
    public string? Opmerking { get; set; }
    public CreateWeegmoment? WeegMoment { get; set; }
    public Guid BehandelaarId { get; set; }
}