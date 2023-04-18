using CommonLibrary.Messaging.Events;

namespace CommonLibrary.Messaging.Interfaces
{
    public interface IEventHandler<in TEvent> where TEvent : BaseEvent
    {
        Task HandleAsync(TEvent @event);
    }
}
