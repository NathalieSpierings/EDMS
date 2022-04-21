using Promeetec.EDMS.Domain.Modules.Declaratie.Aanlevering.Commands;

namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanlevering.Handlers
{
    public class UpdateAanleveringHandler : ICommandHandlerAsync<UpdateAanlevering>
    {
        private readonly IAanleveringRepository _repository;

        public UpdateAanleveringHandler(IAanleveringRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(UpdateAanlevering command)
        {
            var aanlevering = await _repository.GetByIdAsync(command.AggregateRootId);
            if (aanlevering == null)
                throw new ApplicationException($"Aanlevering niet gevonden. Id: {command.AggregateRootId}");

            aanlevering.Update(command);
            await _repository.UpdateAsync(aanlevering);

            return new CommandResponse
            {
                Events = aanlevering.Events
            };
        }
    }
}
