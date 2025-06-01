using AutoLandProcessor.Models;
using AutoLandProcessor.Services;
using ReactiveUI.Fody.Helpers;

namespace AutoLandProcessor.ViewModels
{
	public class ContractsViewModel : DatabaseViewModelBase<Contract>
	{
		private readonly IContractRepository _contractRepository;


		public ContractsViewModel(IRepositoryFactory factory,
								  IAppLoginStateService appLoginState)
									: base(factory.Contracts, appLoginState)
		{
			_contractRepository = factory.Contracts;
		}

		protected override Task<Contract?> ShowAddDialogAsync()
		{
			throw new NotImplementedException();
		}

		protected override Task<bool> ShowDeleteConfirmAsync(Contract model)
		{
			throw new NotImplementedException();
		}

		protected override Task<bool> ShowEditDialogAsync(Contract model)
		{
			throw new NotImplementedException();
		}

		protected override void UpdateUIForUser(User? user)
		{
			if (user != null)
			{

			}
		}
	}
}
