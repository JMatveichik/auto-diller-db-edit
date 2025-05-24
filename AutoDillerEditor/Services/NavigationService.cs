using System.Windows;
using AutoLandProcessor.Views;
using AutoLandProcessor.Models;
using Microsoft.Extensions.DependencyInjection;

namespace AutoLandProcessor.Services
{
	internal class NavigationService : INavigationService
	{
		private readonly IServiceProvider _serviceProvider;

		public NavigationService(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public async Task<User?> ShowLoginDialogAsync()
		{
			var loginDialog = _serviceProvider.GetRequiredService<LoginDialog>();
			loginDialog.Owner = Application.Current.MainWindow;
			loginDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;

			return await Task.Run(() => loginDialog.ShowDialog() == true);
		}
	}
}
