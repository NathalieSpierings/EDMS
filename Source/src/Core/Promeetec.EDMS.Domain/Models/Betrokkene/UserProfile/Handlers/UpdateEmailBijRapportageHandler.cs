using Promeetec.EDMS.Domain.Betrokkene.UserProfile.Commands;

namespace Promeetec.EDMS.Domain.Betrokkene.UserProfile.Handlers
{
    public class UpdateEmailBijRapportageHandler : ICommandHandlerAsync<UpdateEmailBijRapportage>
    {
        private readonly IUserProfileRepository _repository;

        public UpdateEmailBijRapportageHandler(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(UpdateEmailBijRapportage command)
        {
            var userProfile = await _repository.GetByIdAsync(command.AggregateRootId);
            if (userProfile == null)
                throw new ApplicationException($"Profiel niet gevonden. Id: {command.AggregateRootId}");

            userProfile.UpdateEmailBijRapportage(command);
            await _repository.UpdateAsync(userProfile);

            return new CommandResponse
            {
                Events = userProfile.Events
            };
        }
    }
}