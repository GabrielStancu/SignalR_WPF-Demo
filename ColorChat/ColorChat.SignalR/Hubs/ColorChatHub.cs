using ColorChat.Domain;
using Microsoft.AspNetCore.SignalR;

namespace ColorChat.SignalR.Hubs;

public class ColorChatHub : Hub
{
    public async Task SendColorMessage(ColorChatColor color)
    {
        await Clients.All.SendAsync("ReceiveColorMessage", color);
    }
}
