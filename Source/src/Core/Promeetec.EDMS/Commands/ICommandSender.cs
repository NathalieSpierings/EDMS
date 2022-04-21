using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Commands;

public interface ICommandSender
{
    Task<IEnumerable<IEvent>> Send<TCommand>(TCommand command) where TCommand : ICommand;
}