using System.Data;
using Microsoft.EntityFrameworkCore;
using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile.Commands;
using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Domain.Models.Betrokkene.UserProfile.Handlers
{
    public class UpdateEmailBijRapportageHandler : ICommandHandler<UpdateEmailBijRapportage>
    {
        private readonly IUserProfileRepository _repository;

        public UpdateEmailBijRapportageHandler(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<IEvent>> Handle(UpdateEmailBijRapportage command)
        {
            var profile = await _repository.Query().FirstOrDefaultAsync(x => x.Id == command.Id);
            if (profile == null)
                throw new DataException($"Profiel met Id {command.Id} niet gevonden.");

            profile.UpdateEmailBijRapportage(command);
            await _repository.UpdateAsync(profile);

            return new IEvent[] { };
        }
    }
}