using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Modules.Gli.Intake.Commands;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Modules.Gli.Intake.Handlers;

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