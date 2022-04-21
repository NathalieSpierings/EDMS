using Promeetec.EDMS.Domain.Modules.GLI.Behandelplan.Commands;

namespace Promeetec.EDMS.Domain.Modules.GLI.Behandelplan.Handlers
{
    public class WijzigBehandelplanStatusHandler : ICommandHandlerAsync<WijzigBehandelplanStatus>
    {
        private readonly IGliBehandelplanRepository _repository;

        public WijzigBehandelplanStatusHandler(IGliBehandelplanRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(WijzigBehandelplanStatus command)
        {
            var behandelplan = await _repository.GetByIdAsync(command.Id);
            if (behandelplan == null)
                throw new ApplicationException($"GLI behandelplan niet gevonden. Id: {command.Id}");

            behandelplan.WijzigBehandelplanStatus(command);
            await _repository.UpdateAsync(behandelplan);

            return new CommandResponse
            {
                Events = behandelplan.Events
            };
        }
    }
}