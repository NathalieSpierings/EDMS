using Promeetec.EDMS.Domain.Admin.Mededeling.Commands;

namespace Promeetec.EDMS.Domain.Admin.Mededeling.Handlers;

public class UpdateMededelingHandler : ICommandHandlerAsync<UpdateMededeling>
{
    private readonly IMededelingRepository _repository;

    public UpdateMededelingHandler(IMededelingRepository repository)
    {
        _repository = repository;
    }

    public async Task<CommandResponse> HandleAsync(UpdateMededeling command)
    {
        var mededeling = await _repository.GetByIdAsync(command.AggregateRootId);
        if (mededeling == null)
            throw new ApplicationException($"Mededeling niet gevonden. Id: {command.AggregateRootId}");

        mededeling.Update(command);
        await _repository.UpdateAsync(mededeling);

        return new CommandResponse
        {
            Events = mededeling.Events
        };
    }
}