using AutoLandProcessor.Models;
using AutoLandProcessor.Services;


namespace AutoLandProcessor.ViewModels
{

	internal class MainContentViewModel : ViewModelBase
	{
		public MainContentViewModel(UsersViewModel usersViewModel,
									AutomobilesViewModel automobilesViewModel,
									DealersViewModel dealersViewModel,
									ContractsViewModel contractsViewModel,
									IAppLoginStateService appLoginStateService) : base(appLoginStateService)
		{
			UsersViewModel = usersViewModel;
			AutomobilesViewModel = automobilesViewModel;
			DealersViewModel = dealersViewModel;
			ContractsViewModel = contractsViewModel;
		}

		public UsersViewModel UsersViewModel { get; private set; }

		public AutomobilesViewModel AutomobilesViewModel { get; private set; }

		public DealersViewModel DealersViewModel { get; private set; }

		public ContractsViewModel ContractsViewModel { get; private set; }

		protected override void UpdateUIForUser(User? user)
		{
			if (user!=null)
			{

			}
		}
	}
}
