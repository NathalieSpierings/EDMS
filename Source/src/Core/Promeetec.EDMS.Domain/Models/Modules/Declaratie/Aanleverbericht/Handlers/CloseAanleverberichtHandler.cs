using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanleverbericht.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Modules.Declaratie.Aanleverbericht.Handlers;

public class CloseAanleverberichtHandler : ICommandHandler<CloseAanleverbericht>
{
    private readonly IAanleverberichtRepository _repository;

    public CloseAanleverberichtHandler(IAanleverberichtRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<IEvent>> Handle(CloseAanleverbericht command)
    {
        var aanleverbericht = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
        if (aanleverbericht == null)
            throw new DataException($"Aanleverbericht met Id {command.Id} niet gevonden.");

        aanleverbericht.Close();

        await _repository.UpdateAsync(aanleverbericht);

        return new IEvent[] { };
    }
}