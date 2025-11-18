using Demo.ApiClient;
using Demo.ApiClient.IoC;
using Microsoft.Extensions.Logging;

namespace Demo.MauiApiConsumer
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

			//builder.Services.AddDemoApiClientService(x => x.ApiBaseAddress = "http://10.0.2.2:5015/"); // Android emulator
			builder.Services.AddDemoApiClientService(x => x.ApiBaseAddress = "https://localhost:44300/");
			builder.Services.AddTransient<MainPage>();

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
