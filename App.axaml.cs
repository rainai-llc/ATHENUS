using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using AthenusV1.ViewModels;
using AthenusV1.Views;

namespace AthenusV1;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            // Desktop targets (Arch/Windows) get a standard Window
            desktop.MainWindow = new Avalonia.Controls.Window
            {
                Title = "ATHENUS V1 // CMD_CENTER",
                Content = new MainView(), // This points to AthenusV1/Views/MainView.axaml
                DataContext = new MainViewModel(),
                WindowStartupLocation = Avalonia.Controls.WindowStartupLocation.CenterScreen,
                Background = null, // Allows transparency if set in styles
                TransparencyLevelHint = [Avalonia.Controls.WindowTransparencyLevel.AcrylicBlur],
                ExtendClientAreaToDecorationsHint = true
            };
        }
        else if (ApplicationLifetime is ISingleViewApplicationLifetime singleViewPlatform)
        {
            // Mobile/Browser targets just show the MainView directly
            singleViewPlatform.MainView = new MainView
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
