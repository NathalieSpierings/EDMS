using Promeetec.EDMS.Domain.Modules.GLI.Behandelplan.Commands;

namespace Promeetec.EDMS.Domain.Modules.GLI.Behandelplan.Handlers
{
    public class StopbehandelplanHandler : ICommandHandlerAsync<StopBehandelplan>
    {
        private readonly IGliBehandelplanRepository _repository;

        public StopbehandelplanHandler(IGliBehandelplanRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(StopBehandelplan command)
        {
            var behandelplan = await _repository.GetByIdAsync(command.Id);
            if (behandelplan == null)
                throw new ApplicationException($"GLI behandelplan niet gevonden. Id: {command.Id}");

            behandelplan.Stopbehandelplan(command);
            await _repository.UpdateAsync(behandelplan);

            return new CommandResponse
            {
                Events = behandelplan.Events
            };
        }
    }
}