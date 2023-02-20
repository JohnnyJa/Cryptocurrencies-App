using System.Windows.Markup;
using Microsoft.Extensions.DependencyInjection;
using NewApp.Services;
using ViewModel;
using WpfPaging.Services;

namespace App;

public class ViewModelLocator
{
    private static ServiceProvider _provider;

    public static void Init()
    {
        var services = new ServiceCollection();
        services.AddTransient<MainViewModel>();
        services.AddTransient<AssetsViewModel>();
        services.AddScoped<MarketsViewModel>();

        services.AddSingleton<PageService>();
        services.AddSingleton<EventBus>();
        services.AddSingleton<MessageBus>();
        services.AddSingleton<RepositoryService>();

        _provider = services.BuildServiceProvider();

        foreach (var item in services)
        {
            _provider.GetRequiredService(item.ServiceType);
        }
    }

    public MainViewModel MainViewModel => _provider.GetRequiredService<MainViewModel>();
    public AssetsViewModel AssetsViewModel => _provider.GetRequiredService<AssetsViewModel>();
    public MarketsViewModel MarketsViewModel => _provider.GetRequiredService<MarketsViewModel>();

}