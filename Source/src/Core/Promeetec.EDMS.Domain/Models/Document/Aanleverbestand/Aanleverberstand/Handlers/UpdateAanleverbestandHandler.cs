using Promeetec.EDMS.Domain.Document.Aanleverbestand.Aanleverberstand.Commands;

namespace Promeetec.EDMS.Domain.Document.Aanleverbestand.Aanleverberstand.Handlers
{
    public class UpdateAanleverbestandHandler : ICommandHandlerAsync<WijzigAanleverbestand>
    {
        private readonly IAanleverbestandRepository _repository;

        public UpdateAanleverbestandHandler(IAanleverbestandRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(WijzigAanleverbestand command)
        {
            var aanleverbestand = await _repository.GetByIdAsync(command.AggregateRootId);
            if (aanleverbestand == null)
                throw new ApplicationException($"Aanleverbestand niet gevonden. Id: {command.AggregateRootId}");

            aanleverbestand.Update(command);
            await _repository.UpdateAsync(aanleverbestand);

            return new CommandResponse
            {
                Events = aanleverbestand.Events
            };
        }
    }
}
