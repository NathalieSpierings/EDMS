using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Domain.Models.Admin.Mededeling.Commands;

namespace Promeetec.EDMS.Portaal.Domain.Models.Admin.Mededeling.Handlers;

public class UpdateMededelingHandler : ICommandHandler<UpdateMededeling>
{
    private readonly IMededelingRepository _repository;

    public UpdateMededelingHandler(IMededelingRepository repository)
    {
        _repository = repository;
    }
    public async Task<IEnumerable<IEvent>> Handle(UpdateMededeling command)
    {

        var country = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
        if (country == null)
            throw new DataException($"Mededeling met Id {command.Id} niet gevonden.");

        country.Update(command);
        await _repository.UpdateAsync(country);

        return new IEvent[] { };
    }
}