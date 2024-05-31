using TaskManager.Application.Messaging.Interfaces;
using TaskManager.Application.Messaging.Models;

namespace TaskManager.Application.Messaging;

public class StrategyResolver
{
    private readonly Func<string, IEventHandlerStrategy> _strategyAccessor;

    public StrategyResolver(Func<string, IEventHandlerStrategy> strategyAccessor)
    {
        _strategyAccessor = strategyAccessor;
    }

    public Task HandleEvent(UserUpdateEvent updateEvent)
    {
        IEventHandlerStrategy strategy;
        if (updateEvent.AccountStatus == AccountStatus.Blocked || updateEvent.UserStatus == UserStatus.Deleted || updateEvent.UserStatus == UserStatus.Suspended)
        {
            strategy = _strategyAccessor("Delete");
        }
        else if (updateEvent.AccountStatus == AccountStatus.Active || updateEvent.UserStatus == UserStatus.Active)
        {
            strategy = _strategyAccessor("Activate");
        }
        else
        {
            throw new ArgumentException("Unsupported event action");
        }

        return strategy.HandleEvent(updateEvent);
    }
}