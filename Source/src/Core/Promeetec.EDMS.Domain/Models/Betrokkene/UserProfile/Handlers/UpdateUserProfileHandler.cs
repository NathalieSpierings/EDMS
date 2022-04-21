using Promeetec.EDMS.Domain.Betrokkene.UserProfile.Commands;

namespace Promeetec.EDMS.Domain.Betrokkene.UserProfile.Handlers
{
    public class UpdateUserProfileHandler : ICommandHandlerAsync<UpdateUserProfile>
    {
        private readonly IUserProfileRepository _repository;

        public UpdateUserProfileHandler(IUserProfileRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(UpdateUserProfile command)
        {
            var userProfile = await _repository.GetByIdAsync(command.AggregateRootId);
            if (userProfile == null)
                throw new ApplicationException($"Profiel niet gevonden. Id: {command.AggregateRootId}");

            userProfile.Update(command);
            await _repository.UpdateAsync(userProfile);

            return new CommandResponse
            {
                Events = userProfile.Events
            };
        }
    }
}
