using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Core.Commands;

public interface ICommandSender
{
    Task<IEnumerable<IEvent>> Send<TCommand>(TCommand command) where TCommand : ICommand;
}