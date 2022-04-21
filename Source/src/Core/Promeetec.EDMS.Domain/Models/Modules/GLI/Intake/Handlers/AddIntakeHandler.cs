using Promeetec.EDMS.Domain.Modules.GLI.Intake.Commands;

namespace Promeetec.EDMS.Domain.Modules.GLI.Intake.Handlers
{
    public class AddIntakeHandler : ICommandHandlerAsync<NieuweIntake>
    {
        private readonly IGliIntakeRepository _repository;

        public AddIntakeHandler(IGliIntakeRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(NieuweIntake command)
        {
            var intake = new GliIntake(command);
            await _repository.AddAsync(intake);

            return new CommandResponse
            {
                Events = intake.Events
            };
        }
    }
}