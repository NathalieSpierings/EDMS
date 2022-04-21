using Promeetec.EDMS.Domain.Modules.GLI.Intake.Commands;

namespace Promeetec.EDMS.Domain.Modules.GLI.Intake.Handlers
{
    public class VerwerkIntakeHandler : ICommandHandlerAsync<VerwerkIntake>
    {
        private readonly IGliIntakeRepository _repository;

        public VerwerkIntakeHandler(IGliIntakeRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(VerwerkIntake command)
        {
            var intake = await _repository.GetByIdAsync(command.Id);
            if (intake == null)
                throw new ApplicationException($"GLI intake niet gevonden. Id: {command.Id}");

            intake.Verwerk(command);
            await _repository.UpdateAsync(intake);

            return new CommandResponse
            {
                Events = intake.Events
            };
        }
    }
}