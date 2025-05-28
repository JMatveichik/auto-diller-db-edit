using AutoLandProcessor.Models;
using AutoLandProcessor.Services;


namespace AutoLandProcessor.ViewModels
{

	internal class MainContentViewModel : ViewModelBase
	{
		public MainContentViewModel(UsersViewModel usersViewModel,
									CurrentUserViewModel currentUserViewModel,
									AutomobilesViewModel automobilesViewModel,
									DealersViewModel dealersViewModel,
									EquipmentsViewModel equipmentsViewModel,
									WarrantiesViewModel warrantiesViewModel,
									ContractsViewModel contractsViewModel,
									IAppLoginStateService appLoginStateService) : base(appLoginStateService)
		{
			UsersViewModel = usersViewModel;
			AutomobilesViewModel = automobilesViewModel;
			DealersViewModel = dealersViewModel;
			ContractsViewModel = contractsViewModel;
			CurrentUserViewModel = currentUserViewModel;
			EquipmentsViewModel = equipmentsViewModel;
			WarrantiesViewModel = warrantiesViewModel;
		}


		public CurrentUserViewModel CurrentUserViewModel { get; private set; }


		public UsersViewModel UsersViewModel { get; private set; }

		public AutomobilesViewModel AutomobilesViewModel { get; private set; }

		public DealersViewModel DealersViewModel { get; private set; }

		public ContractsViewModel ContractsViewModel { get; private set; }

		public EquipmentsViewModel EquipmentsViewModel { get; private set; }

		public WarrantiesViewModel WarrantiesViewModel { get; private set; }

		protected override void UpdateUIForUser(User? user)
		{
			if (user!=null)
			{

			}
		}
	}
}
