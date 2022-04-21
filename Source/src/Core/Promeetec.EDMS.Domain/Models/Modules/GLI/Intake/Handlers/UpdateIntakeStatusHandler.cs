using Promeetec.EDMS.Domain.Modules.GLI.Intake.Commands;

namespace Promeetec.EDMS.Domain.Modules.GLI.Intake.Handlers
{
    public class UpdateIntakeStatusHandler : ICommandHandlerAsync<WijzigIntakeStatus>
    {
        private readonly IGliIntakeRepository _repository;

        public UpdateIntakeStatusHandler(IGliIntakeRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(WijzigIntakeStatus command)
        {
            var intake = await _repository.GetByIdAsync(command.Id);
            if (intake == null)
                throw new ApplicationException($"GLI intake niet gevonden. Id: {command.Id}");

            intake.UpdateIntakeStatus(command);
            await _repository.UpdateAsync(intake);

            return new CommandResponse
            {
                Events = intake.Events
            };
        }
    }
}