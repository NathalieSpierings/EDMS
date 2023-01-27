using Promeetec.EDMS.Portaal.Core.Commands;
using Promeetec.EDMS.Portaal.Core.Events;
using Promeetec.EDMS.Portaal.Core.Mapping;
using Promeetec.EDMS.Portaal.Core.Queries;

namespace Promeetec.EDMS.Portaal.Core;

public class Dispatcher : IDispatcher
{
    private readonly ICommandSender _commandSender;
    private readonly IQueryProcessor _queryProcessor;
    private readonly IEventPublisher _eventPublisher;
    private readonly IObjectFactory _objectFactory;

    public Dispatcher(ICommandSender commandSender, IQueryProcessor queryProcessor, IEventPublisher eventPublisher, IObjectFactory objectFactory)
    {
        _commandSender = commandSender;
        _queryProcessor = queryProcessor;
        _eventPublisher = eventPublisher;
        _objectFactory = objectFactory;
    }

    public async Task Send<TCommand>(TCommand command) where TCommand : ICommand
    {
        var events = await _commandSender.Send(command);

        var tasks = new List<Task>();

        foreach (var @event in events)
        {
            var concreteEvent = _objectFactory.CreateConcreteObject(@event);
            var task = _eventPublisher.Publish(concreteEvent);
            tasks.Add(task);
        }

        await Task.WhenAll(tasks);
    }

    public async Task<TResult> Get<TResult>(IQuery<TResult> query)
    {
        return await _queryProcessor.Process(query);
    }

    public async Task Publish<TEvent>(TEvent @event) where TEvent : IEvent
    {
        await _eventPublisher.Publish(@event);
    }
}