using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Intake.Handlers;

public class UpdateIntakeStatusHandler : ICommandHandler<UpdateIntakeStatus>
{
    private readonly IGliIntakeRepository _repository;

    public UpdateIntakeStatusHandler(IGliIntakeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<IEvent>> Handle(UpdateIntakeStatus command)
    {
        var intake = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id && x.Verwerkt == false);
        if (intake == null)
            throw new DataException($"GLI intake met Id {command.Id} niet gevonden.");

        intake.UpdateIntakeStatus(command);
        await _repository.UpdateAsync(intake);

        return new IEvent[] { };
    }
}