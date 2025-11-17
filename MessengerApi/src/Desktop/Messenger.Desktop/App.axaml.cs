using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Messenger.Desktop.Services;
using Messenger.Desktop.ViewModels;
using Messenger.Desktop.Views;
using Microsoft.Extensions.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Messenger.Desktop;

public partial class App : Application
{
    public static IServiceProvider? ServiceProvider { get; private set; }

    public App()
    {
        var serviceCollection = new ServiceCollection();
        serviceCollection.AddHttpClient<NetManager>(client =>
        {
            client.BaseAddress = new Uri("https://localhost:44343/");
            client.Timeout = TimeSpan.FromSeconds(30);
        });
        ServiceProvider = serviceCollection.BuildServiceProvider();
    }
    public override void Initialize()
    {
       
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow()
            {
                DataContext = new MainViewModel()
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}
