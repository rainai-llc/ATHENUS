using Avalonia.Controls;
using Avalonia.Input;
using AthenusV1.ViewModels;

namespace AthenusV1.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    private void ChatInput_KeyDown(object? sender, KeyEventArgs e)
    {
        if (e.Key == Key.Enter)
        {
            (DataContext as MainViewModel)?.SendChatMessageCommand.Execute(null);
        }
    }
}
