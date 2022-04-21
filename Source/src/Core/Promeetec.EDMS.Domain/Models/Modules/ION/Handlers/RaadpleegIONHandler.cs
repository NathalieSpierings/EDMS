using Promeetec.EDMS.Domain.Modules.ION.Commands;

namespace Promeetec.EDMS.Domain.Modules.ION.Handlers
{
    public class RaadpleegIONHandler : ICommandHandlerAsync<RaadpleegION>
    {
        public RaadpleegIONHandler()
        {
        }

        public async Task<CommandResponse> HandleAsync(RaadpleegION command)
        {
            await Task.CompletedTask;

            var ion = new IONPatientRelatie();
            ion.Raadpleeg(command);

            return new CommandResponse
            {
                Events = ion.Events
            };
        }
    }
}