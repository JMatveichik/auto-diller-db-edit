using System;
using System.Configuration;
using System.Data;
using System.Windows;
using AutoLandProcessor.Services;
using AutoLandProcessor.ViewModels;
using AutoLandProcessor.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AutoLandProcessor
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public ServiceProvider? ServiceProvider { get; private set; }

		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnStartup(e);

			ServiceCollection services = new ServiceCollection();
			services.RegisterAppServices();

			ServiceProvider = services.BuildServiceProvider();

			var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
			mainWindow.DataContext = ServiceProvider.GetRequiredService<MainWindowViewModel>();
			Application.Current.MainWindow = mainWindow;

			mainWindow.Show();

			/*
			var loginWindow = ServiceProvider.GetRequiredService<LoginDialog>();
			loginWindow.Show();
			*/

		}
	}
}
