using Promeetec.EDMS.Domain.Betrokkene.UserProfile.Commands;

namespace Promeetec.EDMS.Domain.Betrokkene.UserProfile.Handlers
{
    public class TekenIONToestemmingHandler : ICommandHandlerAsync<WijzigIONToestemming>
    {
        private readonly IUserProfileRepository _repository;

        public TekenIONToestemmingHandler(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(WijzigIONToestemming command)
        {
            var userProfile = await _repository.GetByIdAsync(command.AggregateRootId);
            if (userProfile == null)
                throw new ApplicationException($"Profiel niet gevonden. Id: {command.AggregateRootId}");

            userProfile.TekenIONToestemming(command);
            await _repository.UpdateAsync(userProfile);

            return new CommandResponse
            {
                Events = userProfile.Events
            };
        }
    }
}