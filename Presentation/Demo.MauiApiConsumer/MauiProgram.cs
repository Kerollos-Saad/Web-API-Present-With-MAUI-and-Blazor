using Demo.ApiClient;
using Demo.ApiClient.IoC;
using Microsoft.Extensions.Logging;

namespace Demo.MauiApiConsumer
{
	public static class MauiProgram
	{
		public static MauiApp CreateMauiApp()
		{
			// Catch unhandled exceptions
			AppDomain.CurrentDomain.UnhandledException += (sender, args) =>
			{
				var ex = args.ExceptionObject as Exception;
				System.Diagnostics.Debug.WriteLine($"UNHANDLED EXCEPTION: {ex?.Message}");
				System.Diagnostics.Debug.WriteLine($"Stack Trace: {ex?.StackTrace}");
			};

			TaskScheduler.UnobservedTaskException += (sender, args) =>
			{
				System.Diagnostics.Debug.WriteLine($"UNOBSERVED TASK EXCEPTION: {args.Exception.Message}");
				args.SetObserved();
			};

			var builder = MauiApp.CreateBuilder();
			builder
				.UseMauiApp<App>()
				.ConfigureFonts(fonts =>
				{
					fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
					fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
				});

			string apiUrl = "";
#if ANDROID
			apiUrl = DeviceInfo.DeviceType == DeviceType.Virtual
				? "http://10.0.2.2:5015/"
				: "http://192.168.1.111:5015/";

			System.Diagnostics.Debug.WriteLine($"Android Device Type: {DeviceInfo.DeviceType}");
#elif WINDOWS
            apiUrl = "http://localhost:5015/";
#elif IOS
            apiUrl = "http://localhost:5015/";
#else
            apiUrl = "http://192.168.1.111:5015/";
#endif

			System.Diagnostics.Debug.WriteLine($"=== API URL: {apiUrl} ===");

			try
			{
				builder.Services.AddDemoApiClientService(x => x.ApiBaseAddress = apiUrl);
				System.Diagnostics.Debug.WriteLine("API Client Service registered successfully");
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.WriteLine($"ERROR registering API service: {ex.Message}");
				throw;
			}

			builder.Services.AddTransient<MainPage>();

#if DEBUG
			builder.Logging.AddDebug();
			builder.Logging.SetMinimumLevel(LogLevel.Debug);
#endif

			var app = builder.Build();
			System.Diagnostics.Debug.WriteLine("MauiApp built successfully");
			return app;
		}
	}
}