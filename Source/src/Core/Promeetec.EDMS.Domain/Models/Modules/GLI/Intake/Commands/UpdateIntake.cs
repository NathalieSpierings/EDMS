using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Modules.GLI.Weegmoment.Commands;

namespace Promeetec.EDMS.Domain.Models.Modules.Gli.Intake.Commands;

public class UpdateIntake : CommandBase
{
    public DateTime IntakeDatum { get; set; }
    public string? Opmerking { get; set; }
    public CreateWeegmoment? WeegMoment { get; set; }
    public Guid BehandelaarId { get; set; }
}