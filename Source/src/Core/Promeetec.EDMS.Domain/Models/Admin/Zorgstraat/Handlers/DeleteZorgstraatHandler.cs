using Promeetec.EDMS.Domain.Admin.Zorgstraat.Commands;

namespace Promeetec.EDMS.Domain.Admin.Zorgstraat.Handlers;

public class DeleteZorgstraatHandler : ICommandHandlerAsync<DeleteZorgstraat>
{
    private readonly IZorgstraatRepository _repository;

    public DeleteZorgstraatHandler(IZorgstraatRepository repository)
    {
        _repository = repository;
    }


    public async Task<CommandResponse> HandleAsync(DeleteZorgstraat command)
    {
        var zorgstraat = await _repository.GetByIdAsync(command.AggregateRootId);
        if (zorgstraat == null)
            throw new ApplicationException($"Zorgstraat niet gevonden. Id: {command.AggregateRootId}");

        zorgstraat.Delete(command);
        await _repository.UpdateAsync(zorgstraat);

        return new CommandResponse
        {
            Events = zorgstraat.Events
        };
    }
}