using TaskManager.Application.Messaging.Models;

namespace TaskManager.Application.Messaging.Interfaces;

public interface IEventHandlerStrategy
{
    Task HandleEvent(UserUpdateEvent updateEvent);
}