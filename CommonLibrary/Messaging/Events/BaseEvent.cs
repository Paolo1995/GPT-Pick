namespace CommonLibrary.Messaging.Events;
public abstract class BaseEvent
{
    public Guid EventId { get; set; }
    public DateTime Timestamp { get; set; }

    protected BaseEvent()
    {
        EventId = Guid.NewGuid();
        Timestamp = DateTime.UtcNow;
    }
}
