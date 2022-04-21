using Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Commands;

namespace Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Handlers
{
    public class AddVerzekerdeHandler : ICommandHandlerAsync<NieuweVerzekerde>
    {
        private readonly IVerzekerdeRepository _repository;

        public AddVerzekerdeHandler(IVerzekerdeRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(NieuweVerzekerde command)
        {
            var verzekerde = new Verzekerde(command);

            verzekerde.Users.Add(new VerzekerdeToUser
            {
                VerzekerdeId = command.AggregateRootId,
                UserId = command.UserId
            });


            await _repository.AddAsync(verzekerde);

            return new CommandResponse
            {
                Events = verzekerde.Events
            };
        }
    }
}