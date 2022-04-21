using Promeetec.EDMS.Events;

namespace Promeetec.EDMS.Commands;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task<IEnumerable<IEvent>> Handle(TCommand command);
}