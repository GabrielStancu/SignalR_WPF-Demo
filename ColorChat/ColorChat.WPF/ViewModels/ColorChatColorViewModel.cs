using ColorChat.Domain;
using System;
using System.Windows.Media;

namespace ColorChat.WPF.ViewModels;
public class ColorChatColorViewModel : ViewModelBase
{
    public ColorChatColor ColorChatColor { get; set; }

    public Brush ColorBrush
    {
        get
        {
            try
            {
                return new SolidColorBrush(Color.FromRgb(
                    ColorChatColor.Red,
                    ColorChatColor.Green,
                    ColorChatColor.Blue));
            }
            catch (FormatException)
            {
                return new SolidColorBrush(Colors.Black);
            }
        }
    }

    public ColorChatColorViewModel(ColorChatColor colorChatColor)
    {
        ColorChatColor = colorChatColor;
    }
}
