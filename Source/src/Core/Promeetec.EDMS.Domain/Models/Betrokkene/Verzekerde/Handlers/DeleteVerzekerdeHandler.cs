using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Commands;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.Verzekerde.Handlers
{
    public class DeleteVerzekerdeHandler : ICommandHandler<DeleteVerzekerde>
    {
        private readonly IVerzekerdeRepository _repository;

        public DeleteVerzekerdeHandler(IVerzekerdeRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IEvent>> Handle(DeleteVerzekerde command)
        {
            var verzekerde = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
            if (verzekerde == null)
                throw new DataException($"Verzekerde met Id {command.Id} niet gevonden.");

            verzekerde.Delete();
            await _repository.UpdateAsync(verzekerde);

            return new IEvent[] { };
        }
    }
}