using System;
using Avalonia;
using Avalonia.ReactiveUI;

namespace AthenusV1.Desktop;

class Program
{
    // Initialization code. Don't use any Avalonia, xaml, or secondary tremandous 
    // code here, as it will break iOS/Android compatibility.
    [STAThread]
    public static void Main(string[] args) => BuildAvaloniaApp()
        .StartWithClassicDesktopLifetime(args);

    // Avalonia configuration, don't remove; also used by visual designer.
    public static AppBuilder BuildAvaloniaApp()
        => AppBuilder.Configure<AthenusV1.App>() // Points to the App.axaml in your Shared project
            .UsePlatformDetect()
            .WithInterFont()
            .LogToTrace()
            .UseReactiveUI();
}
