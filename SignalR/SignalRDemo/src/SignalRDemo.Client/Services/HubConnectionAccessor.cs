using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRDemo.Client.Services;

public class HubConnectionAccessor : IHubConnectionAccessor
{
    private HubConnection _connection;

    public HubConnectionAccessor()
    {
        _connection = new HubConnectionBuilder()
            .WithUrl("https://localhost:7279/test")
            .Build();
        
        _connection.Closed += async (error) =>
        {
            await Task.Delay(new Random().Next(0,5) * 1000);
            await _connection.StartAsync();
        };
    }

    public async Task<string> Configure()
    {
        var toReturn = string.Empty;
        _connection.On<string>("DoDaThing", (msg) =>
        {
            toReturn = msg;
        });

        return toReturn;
    }

    public async Task StartConnection()
    {
        if (_connection.State == HubConnectionState.Disconnected)
            await _connection.StartAsync();
    }
}