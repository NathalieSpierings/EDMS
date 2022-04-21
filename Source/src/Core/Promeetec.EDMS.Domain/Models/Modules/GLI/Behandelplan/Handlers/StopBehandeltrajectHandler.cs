using Promeetec.EDMS.Domain.Modules.GLI.Behandelplan.Commands;

namespace Promeetec.EDMS.Domain.Modules.GLI.Behandelplan.Handlers
{
    public class StopBehandeltrajectHandler : ICommandHandlerAsync<StopBehandeltraject>
    {
        private readonly IGliBehandelplanRepository _repository;

        public StopBehandeltrajectHandler(IGliBehandelplanRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(StopBehandeltraject command)
        {
            var behandelplan = await _repository.GetByIdAsync(command.Id);
            if (behandelplan == null)
                throw new ApplicationException($"GLI behandelplan niet gevonden. Id: {command.Id}");

            behandelplan.StopBehandeltraject(command);
            await _repository.UpdateAsync(behandelplan);

            return new CommandResponse
            {
                Events = behandelplan.Events
            };
        }
    }
}