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

			//Windows	https://localhost:44300/
			//Android emulator    http://10.0.2.2:5015/
			//Real Android device http://YOUR_PC_IP:5015/
			//iOS Simulator   http://localhost:5015/
			//Real iPhone device http://YOUR_PC_IP:5015/

			string apiUrl = "";

#if ANDROID
			// Android emulator loopback to host
			apiUrl = "http://10.0.2.2:5015/";
#elif WINDOWS
            apiUrl = "https://localhost:44300/";
#elif IOS
            // For iOS simulator, localhost loopback is different
            apiUrl = "http://localhost:5015/";
#else
            // default (real device must use real network IP)
            apiUrl = "http://YOUR_PC_LOCAL_IP:5015/";
#endif

			builder.Services.AddDemoApiClientService(x => x.ApiBaseAddress = apiUrl);
			builder.Services.AddTransient<MainPage>();

#if DEBUG
			builder.Logging.AddDebug();
#endif

			return builder.Build();
		}
	}
}
