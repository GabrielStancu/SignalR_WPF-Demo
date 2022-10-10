using ColorChat.WPF.ViewModels;
using System.Windows;
using ColorChat.WPF.Services;
using Microsoft.AspNetCore.SignalR.Client;

namespace ColorChat.WPF;
/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        HubConnection connection = new HubConnectionBuilder()
            .WithUrl("http://localhost:5000/colorchat")
            .Build();

        var chatService = new SignalRChatService(connection);
        ColorChatViewModel chatViewModel = ColorChatViewModel.CreateConnectedViewModel(chatService);

        MainWindow window = new MainWindow
        {
            DataContext = new MainViewModel(chatViewModel)
        };

        window.Show();
    }
}
