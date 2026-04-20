using Microsoft.Extensions.Logging;
using ProjectManager.Database;
using ProjectManager.Pages;
using ProjectManager.ViewModels;

namespace ProjectManager
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddSingleton<DatabaseService>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<ProjectDetailsPage>();
            builder.Services.AddSingleton<NewProjectPage>();
            builder.Services.AddSingleton<MainViewModel>();
#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
