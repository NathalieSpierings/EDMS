using Promeetec.EDMS.Commands;
using Promeetec.EDMS.Events;
using Promeetec.EDMS.Queries;

namespace Promeetec.EDMS;

public interface IDispatcher
{
    Task Send<TCommand>(TCommand command) where TCommand : ICommand;
    Task<TResult> Get<TResult>(IQuery<TResult> query);
    Task Publish<TEvent>(TEvent @event) where TEvent : IEvent;
}