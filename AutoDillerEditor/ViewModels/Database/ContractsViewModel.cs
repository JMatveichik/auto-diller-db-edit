using AutoLandProcessor.Models;
using AutoLandProcessor.Services;
using ReactiveUI.Fody.Helpers;


namespace AutoLandProcessor.ViewModels
{
	internal class ContractsViewModel : BaseDatabaseViewModel
	{
		private readonly IContractService _contractService;

		[Reactive]
		public IEnumerable<Contract> Contracts { get; private set; } = Enumerable.Empty<Contract>();

		public ContractsViewModel(IContractService contractService, IAppLoginStateService appLoginState) : base(appLoginState)
		{
			_contractService = contractService;
		}
		protected override async Task LoadAsync()
		{
			Contracts = await _contractService.GetAllContractsAsync();
		}

		protected override void UpdateUIForUser(User? user)
		{

		}
	}
}
