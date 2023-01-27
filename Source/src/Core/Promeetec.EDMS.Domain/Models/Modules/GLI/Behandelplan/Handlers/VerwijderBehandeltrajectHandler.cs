using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.GLI.Behandelplan.Handlers;

public class VerwijderBehandeltrajectHandler : ICommandHandler<DeleteBehandeltraject>
{
    private readonly IGliBehandelplanRepository _repository;

    public VerwijderBehandeltrajectHandler(IGliBehandelplanRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<IEvent>> Handle(DeleteBehandeltraject command)
    {
        var behandelplan = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
        if (behandelplan == null)
            throw new DataException($"GLI behandelplan met Id {command.Id} niet gevonden.");


        behandelplan.DeleteBehandeltraject();
        await _repository.UpdateAsync(behandelplan);

        return new IEvent[] { };
    }
}