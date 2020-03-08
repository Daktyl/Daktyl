using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Logging.Serilog;
using Avalonia.Markup.Xaml;
using Daktyl.Desktop.ViewModels;
using Daktyl.Desktop.Views;
using Serilog;
using Serilog.Events;
using System;

namespace Daktyl.Desktop
{
	public class App : Application
	{
		public override void Initialize()
		{
			var logger = new LoggerConfiguration()
				.MinimumLevel.Information()
				.WriteTo.Debug()
				.WriteTo.File("Daktyl.log")
				.CreateLogger();

			SerilogLogger.Initialize(logger);
			Log.Logger = logger;

			Console.SetOut(new LogWriter(LogEventLevel.Information));
			Console.SetError(new LogWriter(LogEventLevel.Error));

			AvaloniaXamlLoader.Load(this);
		}

		public override void OnFrameworkInitializationCompleted()
		{
			if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
				desktop.MainWindow = new MainWindow
				{
					DataContext = new MainWindowViewModel()
				};

			base.OnFrameworkInitializationCompleted();
		}
	}
}