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
			services.AddSingleton<LoginView>();
			services.AddSingleton<CurrentUserView>();

			//register viewmodels
			services.AddTransient<MainWindowViewModel>();
			services.AddTransient<MainContentViewModel>();
			services.AddTransient<UsersViewModel>();
			services.AddTransient<AutomobilesViewModel>();
			services.AddTransient<DealersViewModel>();
			services.AddTransient<ContractsViewModel>();
			services.AddTransient<LoginViewModel>();
			services.AddTransient<CurrentUserViewModel>();

			//register services
			services.AddTransient<IUserService, UserService>();
			services.AddTransient<IAutomobileService, AutomobileService>();
			services.AddTransient<IDealerService, DealerService>();
			services.AddTransient<IContractService, ContractService>();
			services.AddSingleton<IAppLoginStateService, AppLoginStateService>();

			return services;
		}
	}
}
