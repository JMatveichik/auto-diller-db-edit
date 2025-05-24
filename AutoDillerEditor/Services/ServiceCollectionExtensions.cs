using Microsoft.Extensions.DependencyInjection;
using AutoLandProcessor.ViewModels;
using AutoLandProcessor.Views;
using Microsoft.EntityFrameworkCore;
using AutoLandProcessor.Data;
using System.Configuration;

namespace AutoLandProcessor.Services
{
	internal static class ServiceCollectionExtensions
	{
		public static IServiceCollection RegisterAppServices(this ServiceCollection services)
		{
			// Регистрация DbContext с использованием SQLite
			services.AddDbContext<AppDatabaseContext>(options =>
			{
				var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
				options.UseSqlite(connectionString);
			});

			//register views
			services.AddSingleton<MainWindow>();
			services.AddSingleton<UsersView>();
			services.AddSingleton<AutomobilesView>();
			services.AddSingleton<ContractsView>();
			services.AddSingleton<LoginDialog>();

			//register viewmodels
			services.AddSingleton<MainWindowViewModel>();
			services.AddSingleton<UsersViewModel>();
			services.AddSingleton<AutomobilesViewModel>();
			services.AddSingleton<DealersViewModel>();
			services.AddSingleton<ContractsViewModel>();
			services.AddSingleton<LoginViewModel>();

			//register services
			services.AddScoped<IUserService, UserService>();
			services.AddScoped<IAutomobileService, AutomobileService>();
			services.AddScoped<IDealerService, DealerService>();
			services.AddScoped<IContractService, ContractService>();

			return services;
		}
	}
}
