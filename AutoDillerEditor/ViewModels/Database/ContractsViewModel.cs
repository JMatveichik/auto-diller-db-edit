using AutoLandProcessor.Models;
using AutoLandProcessor.Services;
using ReactiveUI.Fody.Helpers;


namespace AutoLandProcessor.ViewModels
{
	public class ContractsViewModel : BaseDatabaseViewModel
	{
		private readonly IContractRepository _contractService;

		[Reactive]
		public IEnumerable<Contract> Contracts { get; private set; } = Enumerable.Empty<Contract>();

		public ContractsViewModel(IContractRepository contractService, IAppLoginStateService appLoginState) : base(appLoginState)
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
