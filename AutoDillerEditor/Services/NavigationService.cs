using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using AutoLandProcessor.Views;
using Microsoft.Extensions.DependencyInjection;

namespace AutoLandProcessor.Services
{
	internal class NavigationService : INavigationService
	{
		private readonly IServiceProvider _serviceProvider;
		private LoginDialog? _loginDialog;

		public NavigationService(IServiceProvider serviceProvider)
		{
			_serviceProvider = serviceProvider;
		}

		public void ShowLoginDialog()
		{
			Application.Current.Dispatcher.Invoke(() =>
			{
				_loginDialog = _serviceProvider.GetRequiredService<LoginDialog>();
				_loginDialog.Owner = Application.Current.MainWindow;
				_loginDialog.WindowStartupLocation = WindowStartupLocation.CenterOwner;
				_loginDialog.ShowDialog();
			});
		}

		public void CloseLoginDialog()
		{
			Application.Current.Dispatcher.Invoke(() =>
			{
				_loginDialog?.Close();
				_loginDialog = null;
			});
		}

		public void ShowMainView()
		{
			throw new NotImplementedException();
		}
	}
}
