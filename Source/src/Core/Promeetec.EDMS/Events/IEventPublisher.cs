namespace Promeetec.EDMS.Events;

public interface IEventPublisher
{
    Task Publish<TEvent>(TEvent @event) where TEvent : IEvent;
}