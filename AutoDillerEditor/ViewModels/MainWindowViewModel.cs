

namespace AutoLandProcessor.ViewModels
{
	internal class MainWindowViewModel : ViewModelBase
	{
		public UsersViewModel UsersViewModel { get; private set; }

		public AutomobilesViewModel AutomobilesViewModel{ get; private set; }

		public DealersViewModel	DealersViewModel { get; private set; }

		public ContractsViewModel ContractsViewModel { get; private set; }

		public MainWindowViewModel(	UsersViewModel usersViewModel,
									AutomobilesViewModel automobilesViewModel,
									DealersViewModel deallersViewModel,
									ContractsViewModel contractsViewModel)
		{
			UsersViewModel = usersViewModel;
			AutomobilesViewModel = automobilesViewModel;
			DealersViewModel = deallersViewModel;
			ContractsViewModel = contractsViewModel;
		}
	}
}
