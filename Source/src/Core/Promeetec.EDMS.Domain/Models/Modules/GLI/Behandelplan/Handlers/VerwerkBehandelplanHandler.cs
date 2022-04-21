using Promeetec.EDMS.Domain.Modules.GLI.Behandelplan.Commands;

namespace Promeetec.EDMS.Domain.Modules.GLI.Behandelplan.Handlers
{
    public class VerwerkGliRegistratieHandler : ICommandHandlerAsync<VerwerkBehandelplan>
    {
        private readonly IGliBehandelplanRepository _repository;

        public VerwerkGliRegistratieHandler(IGliBehandelplanRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(VerwerkBehandelplan command)
        {
            var behandelplan = await _repository.GetByIdAsync(command.AggregateRootId);
            if (behandelplan == null)
                throw new ApplicationException($"GLI behandelplan niet gevonden. Id: {command.AggregateRootId}");

            behandelplan.Verwerk(command);
            await _repository.UpdateAsync(behandelplan);

            return new CommandResponse
            {
                Events = behandelplan.Events
            };
        }
    }
}