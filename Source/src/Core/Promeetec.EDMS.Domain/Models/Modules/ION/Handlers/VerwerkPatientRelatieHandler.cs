using Promeetec.EDMS.Domain.Modules.ION.Commands;

namespace Promeetec.EDMS.Domain.Modules.ION.Handlers
{
    public class VerwerkPatientRelatieHandler : ICommandHandlerAsync<VerwerkPatientRelatie>
    {
        private readonly IIONPopulatieRepository _repository;

        public VerwerkPatientRelatieHandler(IIONPopulatieRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(VerwerkPatientRelatie command)
        {
            var ion = await _repository.GetByIdAsync(command.AggregateRootId);
            if (ion == null)
                throw new ApplicationException($"Patient relatie niet gevonden. Id: {command.AggregateRootId}");

            ion.Verwerk(command);
            await _repository.UpdateAsync(ion);

            return new CommandResponse
            {
                Events = ion.Events
            };
        }
    }
}