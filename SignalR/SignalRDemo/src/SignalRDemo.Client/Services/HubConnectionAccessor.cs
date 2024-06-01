using Microsoft.AspNetCore.SignalR.Client;

namespace SignalRDemo.Client.Services;

public class HubConnectionAccessor : IHubConnectionAccessor
{
    private HubConnection _connection;
    public event Action<string> OnMessageReceived;
    
    public HubConnectionAccessor()
    {
        // _connection = new HubConnectionBuilder()
        //     .WithUrl("https://localhost:7279/test")
        //     .ConfigureLogging(logging =>
        //     {
        //         logging.AddConsole(); // Add console logging
        //         logging.SetMinimumLevel(LogLevel.Debug); // Set log level to Debug
        //     })
        //     .Build();
        //
        // _connection.Closed += async (error) =>
        // {
        //     await Task.Delay(new Random().Next(0,5) * 1000);
        //     await _connection.StartAsync();
        // };
        //
        // _connection.On<string>("DoDaThing", (msg) =>
        // {
        //     OnMessageReceived?.Invoke(msg);
        // });
    }

    public async Task StartConnection()
    {
        if (_connection.State == HubConnectionState.Disconnected)
            await _connection.StartAsync();
    }
}