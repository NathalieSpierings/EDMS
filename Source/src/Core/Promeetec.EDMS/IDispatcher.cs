using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Core.Queries;

namespace Promeetec.EDMS.Portaal.Core;

public interface IDispatcher
{
    Task Send<TCommand>(TCommand command) where TCommand : ICommand;
    Task<TResult> Get<TResult>(IQuery<TResult> query);
    Task Publish<TEvent>(TEvent @event) where TEvent : IEvent;
}