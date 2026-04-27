namespace AsyncRecipe;

using AsyncRecipe.Core.Services;
using AsyncRecipe.Infrastructure;
using AsyncRecipe.ViewModels;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont(
                    "OpenSans-Regular.ttf",
                    "OpenSansRegular"
                );
                fonts.AddFont(
                    "OpenSans-Semibold.ttf",
                    "OpenSansSemibold"
                );
            });

        // Configure dependency injection
        var services = builder.Services;

        // Core services
        services.AddSingleton<ITodoService, MockTodoService>();

        // ViewModels
        services.AddTransient<TodoListViewModel>();

        // Pages
        services.AddTransient<MainPage>();
        services.AddTransient<AppShell>();

        return builder.Build();
    }
}

