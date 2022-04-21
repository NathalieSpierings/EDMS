using Promeetec.EDMS.Domain.Modules.GLI.Intake.Commands;

namespace Promeetec.EDMS.Domain.Modules.GLI.Intake.Handlers
{
    public class UpdateIntakeHandler : ICommandHandlerAsync<WijzigIntake>
    {
        private readonly IGliIntakeRepository _repository;

        public UpdateIntakeHandler(IGliIntakeRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(WijzigIntake command)
        {
            var intake = await _repository.GetByIdAsync(command.Id);
            if (intake == null)
                throw new ApplicationException($"GLI intake niet gevonden. Id: {command.Id}");

            intake.UpdateIntake(command);
            await _repository.UpdateAsync(intake);

            return new CommandResponse
            {
                Events = intake.Events
            };
        }
    }
}