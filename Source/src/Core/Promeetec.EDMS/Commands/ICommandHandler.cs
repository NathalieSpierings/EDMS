using Promeetec.EDMS.Portaal.Core.Events;

namespace Promeetec.EDMS.Portaal.Core.Commands;

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task<IEnumerable<IEvent>> Handle(TCommand command);
}