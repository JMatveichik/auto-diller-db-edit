using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using AutoLandProcessor.Models;
using AutoLandProcessor.Services;
using System.Net.NetworkInformation;

namespace AutoLandProcessor.ViewModels
{
	internal class MainWindowViewModel : ViewModelBase
	{
		private readonly INavigationService _navigationService;


		public UsersViewModel UsersViewModel { get; private set; }

		public AutomobilesViewModel AutomobilesViewModel{ get; private set; }

		public DealersViewModel	DealersViewModel { get; private set; }

		public ContractsViewModel ContractsViewModel { get; private set; }

		public MainWindowViewModel(	UsersViewModel usersViewModel,
									AutomobilesViewModel automobilesViewModel,
									DealersViewModel deallersViewModel,
									ContractsViewModel contractsViewModel,
									INavigationService navigationService,
									IAppLoginStateService appLoginStateService) :
									base(appLoginStateService)
		{
			UsersViewModel		 = usersViewModel;
			AutomobilesViewModel = automobilesViewModel;
			DealersViewModel	 = deallersViewModel;
			ContractsViewModel   = contractsViewModel;

			_navigationService = navigationService;
		}

		protected override void UpdateUIForUser(User? user)
		{

		}
	}
}
