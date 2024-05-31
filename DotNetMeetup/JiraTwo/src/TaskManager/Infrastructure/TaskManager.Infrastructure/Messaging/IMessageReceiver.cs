using TaskManager.Application.Messaging.Models;

namespace TaskManager.Infrastructure.Messaging;

public interface IMessageReceiver
{
    public event Action<UserUpdateEvent> OnMessageReceived;
    void ReceiveMessage();
}