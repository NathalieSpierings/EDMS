using Promeetec.EDMS.Domain.Betrokkene.Weegmoment.Commands;

namespace Promeetec.EDMS.Domain.Betrokkene.Weegmoment.Handlers
{
    public class AddWeegMomentHandler : ICommandHandlerAsync<NieuwWeegMoment>
    {
        private readonly IWeegMomentRepository _repository;

        public AddWeegMomentHandler(IWeegMomentRepository repository)
        {
            _repository = repository;
        }

        public async Task<CommandResponse> HandleAsync(NieuwWeegMoment command)
        {
            var weegmoment = new Betrokkene.Weegmoment.Weegmoment(command);
            await _repository.AddAsync(weegmoment);

            return new CommandResponse
            {
                Events = weegmoment.Events
            };
        }
    }
}