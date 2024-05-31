namespace SignalRDemo.Api.Hubs;

public interface ITestHub
{
    Task DoDaThing(string guid);
}