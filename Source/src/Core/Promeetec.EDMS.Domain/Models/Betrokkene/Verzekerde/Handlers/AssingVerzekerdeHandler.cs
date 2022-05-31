using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Commands;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Handlers
{
    public class AssingVerzekerdeHandler : ICommandHandler<AssingVerzekerde>
    {
        private readonly IVerzekerdeRepository _repository;

        public AssingVerzekerdeHandler(IVerzekerdeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IEvent>> Handle(AssingVerzekerde command)
        {
            var verzekerde = await _repository.Query().Include(i => i.Users).FirstOrDefaultAsync(x => x.Id == command.Id);
            if (verzekerde == null)
                throw new DataException($"Verzekerde met Id {command.Id} niet gevonden.");


            if (command.UserIds.Any())
            {
                verzekerde.Users.ToList().RemoveAll(x => x.UserId != verzekerde.AangemaaktDoorId);
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
                verzekerde.Users.ToList().RemoveAll(x => x.UserId != verzekerde.AangemaaktDoorId);
                verzekerde.Shared = false;
                await _repository.UpdateAsync(verzekerde);
            }

            return new IEvent[] { };
        }
    }
}