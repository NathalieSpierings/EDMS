namespace Promeetec.EDMS.Portaal.Core.Events;

public interface IEventHandler<in TEvent> where TEvent : IEvent
{
    Task Handle(TEvent @event);
}