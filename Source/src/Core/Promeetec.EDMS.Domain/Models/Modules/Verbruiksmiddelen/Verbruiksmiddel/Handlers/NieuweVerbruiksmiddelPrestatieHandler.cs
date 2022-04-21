using Promeetec.EDMS.Domain.Modules.Verbruiksmiddelen.Verbruiksmiddel.Commands;

namespace Promeetec.EDMS.Domain.Modules.Verbruiksmiddelen.Verbruiksmiddel.Handlers
{
    public class NieuweVerbruiksmiddelPrestatieHandler : ICommandHandlerAsync<NieuweVerbruiksmiddelPrestatie>
    {
        private readonly IVerbruiksmiddelPrestatieRepository _repository;

        public NieuweVerbruiksmiddelPrestatieHandler(IVerbruiksmiddelPrestatieRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(NieuweVerbruiksmiddelPrestatie command)
        {
            var prestatie = new VerbruiksmiddelPrestatie(command);
            await _repository.AddAsync(prestatie);

            return new CommandResponse
            {
                Events = prestatie.Events
            };
        }
    }
}