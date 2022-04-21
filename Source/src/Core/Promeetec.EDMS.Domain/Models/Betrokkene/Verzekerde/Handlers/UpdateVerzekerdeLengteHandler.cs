using Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Commands;

namespace Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Handlers
{
    public class UpdateVerzekerdeLengteHandler : ICommandHandlerAsync<UpdateVerzekerdeLengte>
    {
        private readonly IVerzekerdeRepository _repository;

        public UpdateVerzekerdeLengteHandler(IVerzekerdeRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(UpdateVerzekerdeLengte command)
        {
            var verzekerde = await _repository.GetByIdAsync(command.Id);
            if (verzekerde == null)
                throw new ApplicationException($"Cliënt niet gevonden. Id: {command.Id}");

            verzekerde.Update(command.Lengte);
            await _repository.UpdateAsync(verzekerde);

            return new CommandResponse
            {
                Events = verzekerde.Events
            };
        }
    }
}