namespace Promeetec.EDMS.Portaal.Core.Events;

public interface IEventPublisher
{
    Task Publish<TEvent>(TEvent @event) where TEvent : IEvent;
}