using Microsoft.Extensions.DependencyInjection;
using AutoLandProcessor.ViewModels;
using AutoLandProcessor.Views;
using Microsoft.EntityFrameworkCore;
using AutoLandProcessor.Data;
using System.Configuration;

namespace AutoLandProcessor.Services
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection RegisterAppServices(this ServiceCollection services)
		{
			// Регистрация DbContext с использованием SQLite
			services.AddDbContext<AppDBContext>(options =>
			{
				var connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
				options.UseSqlite(connectionString);
			});

			//register views
			services.AddSingleton<MainWindow>();
			services.AddSingleton<UsersView>();
			services.AddSingleton<AutomobilesView>();
			services.AddSingleton<ContractsView>();
			services.AddSingleton<EquipmentsView>();
			services.AddSingleton<WarrantiesView>();
			services.AddSingleton<LoginView>();
			services.AddSingleton<CurrentUserView>();
			services.AddSingleton<EditUserDialog>();

			//register viewmodels
			services.AddTransient<MainWindowViewModel>();
			services.AddTransient<MainContentViewModel>();
			services.AddTransient<UsersViewModel>();
			services.AddTransient<AutomobilesViewModel>();
			services.AddTransient<DealersViewModel>();
			services.AddTransient<ContractsViewModel>();
			services.AddTransient<EquipmentsViewModel>();
			services.AddTransient<WarrantiesViewModel>();
			services.AddTransient<LoginViewModel>();
			services.AddTransient<CurrentUserViewModel>();

			//register services
			services.AddTransient<IUserRepository, UserRepository>();
			services.AddTransient<IAutomobileRepository, AutomobileRepository>();
			services.AddTransient<IDealerRepository, DealerRepository>();
			services.AddTransient<IContractRepository, ContractRepository>();
			services.AddTransient<IEquipmentRepository, EquipmentRepository>();
			services.AddTransient<IWarrantyRepository, WarrantyRepository>();
			services.AddSingleton<IAppLoginStateService, AppLoginStateService>();
			services.AddSingleton<IUserDialogService, UserDialogService>();

			return services;
		}
	}
}
