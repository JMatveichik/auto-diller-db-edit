using ReactiveUI;
using ReactiveUI.Fody.Helpers;

using AutoLandProcessor.Models;

namespace AutoLandProcessor.ViewModels
{
	internal class MainWindowViewModel : ViewModelBase
	{

		[Reactive]
		public User CurrentUser { get; set; }

		public UsersViewModel UsersViewModel { get; private set; }

		public AutomobilesViewModel AutomobilesViewModel{ get; private set; }

		public DealersViewModel	DealersViewModel { get; private set; }

		public ContractsViewModel ContractsViewModel { get; private set; }

		public MainWindowViewModel(	UsersViewModel usersViewModel,
									AutomobilesViewModel automobilesViewModel,
									DealersViewModel deallersViewModel,
									ContractsViewModel contractsViewModel,
									User user)
		{
			UsersViewModel		 = usersViewModel;
			AutomobilesViewModel = automobilesViewModel;
			DealersViewModel	 = deallersViewModel;
			ContractsViewModel   = contractsViewModel;
			CurrentUser = user;
		}
	}
}
