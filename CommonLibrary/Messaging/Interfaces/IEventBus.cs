using CommonLibrary.Messaging.Events;

namespace CommonLibrary.Messaging.Interfaces;
public interface IEventBus
{
    Task PublishAsync<TEvent>(TEvent @event) where TEvent : BaseEvent;
    void Subscribe<TEvent, THandler>() where TEvent : BaseEvent where THandler : IEventHandler<TEvent>;
}
