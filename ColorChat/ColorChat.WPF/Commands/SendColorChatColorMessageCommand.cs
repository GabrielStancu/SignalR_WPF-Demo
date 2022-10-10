using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using ColorChat.Domain;
using ColorChat.WPF.Services;
using ColorChat.WPF.ViewModels;

namespace ColorChat.WPF.Commands;
public class SendColorChatColorMessageCommand : ICommand
{
    private readonly ColorChatViewModel _viewModel;
    private readonly SignalRChatService _chatService;

    public SendColorChatColorMessageCommand(ColorChatViewModel viewModel, SignalRChatService chatService)
    {
        _viewModel = viewModel;
        _chatService = chatService;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public async void Execute(object? parameter)
    {
        try
        {
            var color = new ColorChatColor
            {
                Red = _viewModel.Red,
                Green = _viewModel.Green,
                Blue = _viewModel.Blue
            };

            await _chatService.SendColorMessageAsync(color);

            _viewModel.ErrorMessage = string.Empty;
        }
        catch (Exception)
        {
            _viewModel.ErrorMessage = "Unable to send color message";
        }
    }

    public event EventHandler? CanExecuteChanged;
}
