using Promeetec.EDMS.Domain.Modules.ION.Commands;

namespace Promeetec.EDMS.Domain.Modules.ION.Handlers
{
    public class NieuwePatientRelatieHandler : ICommandHandlerAsync<CreatePatientRelatie>
    {
        private readonly IIONPopulatieRepository _repository;

        public NieuwePatientRelatieHandler(IIONPopulatieRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(CreatePatientRelatie command)
        {
            var relatie = new IONPatientRelatie(command);
            await _repository.AddAsync(relatie);

            return new CommandResponse
            {
                Events = relatie.Events
            };
        }
    }
}