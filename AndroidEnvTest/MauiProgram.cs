using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace AndroidEnvTest;
public static class MauiProgram
{
    static void Log(string message) => Trace.WriteLine(message);

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

#if DEBUG
		builder.Logging.AddDebug();
#endif

        System.Collections.IDictionary variables = Environment.GetEnvironmentVariables();
        foreach (var key in variables.Keys)
        {
            Log($"{key}={variables[key]}");
        }

        return builder.Build();
    }
}
