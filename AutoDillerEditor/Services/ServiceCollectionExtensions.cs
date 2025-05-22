using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using AutoDillerEditor.ViewModels;
using AutoDillerEditor.Views;

namespace AutoDillerEditor.Services
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
