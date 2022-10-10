using System;
using System.Threading.Tasks;
using ColorChat.Domain;
using Microsoft.AspNetCore.SignalR.Client;

namespace ColorChat.WPF.Services;
public class SignalRChatService
{
    private readonly HubConnection _connection;

    public event Action<ColorChatColor> ColorMessageReceived;

    public SignalRChatService(HubConnection connection)
    {
        _connection = connection;
        _connection.On<ColorChatColor>("ReceiveColorMessage", (color) => ColorMessageReceived?.Invoke(color));
    }

    public async Task ConnectAsync()
    {
        await _connection.StartAsync();
    }

    public async Task SendColorMessageAsync(ColorChatColor color)
    {
        await _connection.SendAsync("SendColorMessage", color);
    }
}
