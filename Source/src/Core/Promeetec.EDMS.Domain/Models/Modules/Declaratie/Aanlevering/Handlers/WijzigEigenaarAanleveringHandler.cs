using Promeetec.EDMS.Domain.Modules.Declaratie.Aanlevering.Commands;

namespace Promeetec.EDMS.Domain.Modules.Declaratie.Aanlevering.Handlers
{
    public class WijzigEigenaarAanleveringHandler : ICommandHandlerAsync<ChangeEigenaarAanlevering>
    {
        private readonly IAanleveringRepository _repository;

        public WijzigEigenaarAanleveringHandler(IAanleveringRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(ChangeEigenaarAanlevering command)
        {
            var aanlevering = await _repository.GetByIdAsync(command.AggregateRootId);
            if (aanlevering == null)
                throw new ApplicationException($"Aanlevering niet gevonden. Id: {command.AggregateRootId}");

            aanlevering.WijzigEigenaar(command);
            await _repository.UpdateAsync(aanlevering);

            return new CommandResponse
            {
                Events = aanlevering.Events
            };
        }
    }
}