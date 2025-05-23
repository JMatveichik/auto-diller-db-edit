using Microsoft.Extensions.DependencyInjection;
using AutoLandProcessor.ViewModels;
using AutoLandProcessor.Views;

namespace AutoLandProcessor.Services
{
	internal static class ServiceCollectionExtensions
	{
		public static IServiceCollection RegisterAppServices(this ServiceCollection services)
		{
			//register views
			services.AddSingleton<MainWindow>();

			//register viewmodels
			services.AddSingleton<MainWindowViewModel>();

			//register services

			return services;
		}
	}
}
