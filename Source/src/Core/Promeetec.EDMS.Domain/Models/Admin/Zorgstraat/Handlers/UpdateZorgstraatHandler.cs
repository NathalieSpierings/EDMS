using Promeetec.EDMS.Domain.Admin.Zorgstraat.Commands;

namespace Promeetec.EDMS.Domain.Admin.Zorgstraat.Handlers;

public class UpdateZorgstraatHandler : ICommandHandlerAsync<UpdateZorgstraat>
{
    private readonly IZorgstraatRepository _repository;

    public UpdateZorgstraatHandler(IZorgstraatRepository repository)
    {
        _repository = repository;
    }


    public async Task<CommandResponse> HandleAsync(UpdateZorgstraat command)
    {
        var zorgstraat = await _repository.GetByIdAsync(command.AggregateRootId);
        if (zorgstraat == null)
            throw new ApplicationException($"Zorgstraat niet gevonden. Id: {command.AggregateRootId}");

        zorgstraat.Update(command);
        await _repository.UpdateAsync(zorgstraat);

        return new CommandResponse
        {
            Events = zorgstraat.Events
        };
    }
}