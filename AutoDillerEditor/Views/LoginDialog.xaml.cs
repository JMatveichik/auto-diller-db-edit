using AutoLandProcessor.Services;
using AutoLandProcessor.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace AutoLandProcessor.Views
{
	/// <summary>
	/// Interaction logic for LoginDialog.xaml
	/// </summary>
	internal partial class LoginDialog : Window
	{
		public LoginDialog(LoginViewModel viewModel, INavigationService navigationService, IAppLoginStateService appState)
		{
			InitializeComponent();
			DataContext = viewModel;

			WindowStartupLocation = WindowStartupLocation.CenterScreen;

			viewModel.LoginCommand.Subscribe(user =>
			{
				if (user != null)
				{
					appState.CurrentUser = user;
					navigationService.CloseLoginDialog();
				}
			});
		}
	}
}
