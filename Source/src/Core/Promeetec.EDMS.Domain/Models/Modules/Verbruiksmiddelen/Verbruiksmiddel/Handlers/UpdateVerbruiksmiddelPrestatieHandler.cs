using Promeetec.EDMS.Domain.Modules.Verbruiksmiddelen.Verbruiksmiddel.Commands;

namespace Promeetec.EDMS.Domain.Modules.Verbruiksmiddelen.Verbruiksmiddel.Handlers
{
    public class UpdateVerbruiksmiddelPrestatieHandler : ICommandHandlerAsync<WijzigVerbruiksmiddelPrestatie>
    {
        private readonly IVerbruiksmiddelPrestatieRepository _repository;

        public UpdateVerbruiksmiddelPrestatieHandler(IVerbruiksmiddelPrestatieRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(WijzigVerbruiksmiddelPrestatie command)
        {
            var prestatie = await _repository.GetByIdAsync(command.AggregateRootId);
            if (prestatie == null)
                throw new ApplicationException($"Prestatie niet gevonden. Id: {command.AggregateRootId}");

            prestatie.Update(command);
            await _repository.UpdateAsync(prestatie);

            return new CommandResponse
            {
                Events = prestatie.Events
            };
        }
    }
}