using AgendaApp.Data.Interfaces;
using AgendaApp.Data.Repositories;
using AgendaApp.Services.Interfaces;
using AgendaApp.Services.Services;
using Microsoft.Extensions.Logging;
using Microsoft.JSInterop;

namespace AgendaApp.UI
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif

            builder.Services.AddTransient<ITarefaRepository, TarefaRepository>();
            builder.Services.AddTransient<ITarefaService, TarefaService>();            

            return builder.Build();
        }
    }
}