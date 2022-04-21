namespace Promeetec.EDMS.Events;

public interface IEventHandler<in TEvent> where TEvent : IEvent
{
    Task Handle(TEvent @event);
}