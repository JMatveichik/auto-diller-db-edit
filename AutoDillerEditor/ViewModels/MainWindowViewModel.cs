using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using AutoLandProcessor.Models;
using AutoLandProcessor.Services;
using System.Net.NetworkInformation;

namespace AutoLandProcessor.ViewModels
{
	public class MainWindowViewModel : ViewModelBase
	{

		[Reactive]
		public object CurrentView { get; private set; } = new();

		public LoginViewModel LoginViewModel { get; private set; }

		public MainContentViewModel MainContentViewModel { get; private set; }


		public MainWindowViewModel(	LoginViewModel loginViewModel,
									MainContentViewModel mainContentViewModel,
									IAppLoginStateService appLoginStateService) :
									base(appLoginStateService)
		{
			MainContentViewModel = mainContentViewModel;
			LoginViewModel		 = loginViewModel;
			CurrentView			 = LoginViewModel;

		}

		public void ShowLogin()
		{
			CurrentView = LoginViewModel;
		}

		public void ShowMainContent()
		{
			CurrentView = MainContentViewModel;
		}
		protected override void UpdateUIForUser(User? user)
		{
			CurrentView = (user == null) ? LoginViewModel : MainContentViewModel;
		}
	}
}
