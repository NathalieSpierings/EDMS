using Promeetec.EDMS.Domain.Document.Aanleverbestand.Aanleverberstand.Commands;

namespace Promeetec.EDMS.Domain.Document.Aanleverbestand.Aanleverberstand.Handlers
{
    public class UpdateAanleverbestandWorkflowStateHandler : ICommandHandlerAsync<WijzigAanleverbestandWorkflowState>
    {
        private readonly IAanleverbestandRepository _repository;

        public UpdateAanleverbestandWorkflowStateHandler(IAanleverbestandRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(WijzigAanleverbestandWorkflowState command)
        {
            var aanleverbestand = await _repository.GetByIdAsync(command.AggregateRootId);
            if (aanleverbestand == null)
                throw new ApplicationException($"Aanleverbestand niet gevonden. Id: {command.AggregateRootId}");

            aanleverbestand.UpdateWorkflowState(command);
            await _repository.UpdateAsync(aanleverbestand);

            return new CommandResponse
            {
                Events = aanleverbestand.Events
            };
        }
    }
}
