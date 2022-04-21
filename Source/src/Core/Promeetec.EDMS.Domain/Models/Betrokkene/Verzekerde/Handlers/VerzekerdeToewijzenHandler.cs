using Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Commands;

namespace Promeetec.EDMS.Domain.Betrokkene.Verzekerde.Handlers
{
    public class VerzekerdeToewijzenHandler : ICommandHandlerAsync<ToewijzenVerzekerde>
    {
        private readonly IVerzekerdeRepository _repository;

        public VerzekerdeToewijzenHandler(IVerzekerdeRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(ToewijzenVerzekerde command)
        {
            var verzekerde = await _repository.Query()
                .Include(i => i.Users)
                .Where(x => x.Id == command.AggregateRootId)
                .FirstOrDefaultAsync();

            if (verzekerde == null)
                throw new ApplicationException($"Verzekerde niet gevonden. Id: {command.AggregateRootId}");

            if (command.UserIds != null)
            {
                verzekerde.Users.RemoveAll(x => x.UserId != verzekerde.AangemaaktDoorId);
                await _repository.UpdateAsync(verzekerde);

                foreach (var id in command.UserIds)
                {
                    verzekerde.Users.Add(new VerzekerdeToUser
                    {
                        VerzekerdeId = verzekerde.Id,
                        UserId = id
                    });
                }

                verzekerde.Shared = verzekerde.Users.Count > 1;
                await _repository.UpdateAsync(verzekerde);
            }
            else
            {
                verzekerde.Users.RemoveAll(x => x.UserId != verzekerde.AangemaaktDoorId);
                verzekerde.Shared = false;
                await _repository.UpdateAsync(verzekerde);
            }

            return new CommandResponse
            {
                Events = verzekerde.Events
            };
        }
    }
}