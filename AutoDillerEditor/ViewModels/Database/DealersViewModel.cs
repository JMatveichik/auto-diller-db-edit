using AutoLandProcessor.Models;
using AutoLandProcessor.Services;
using ReactiveUI.Fody.Helpers;

namespace AutoLandProcessor.ViewModels
{
    internal class DealersViewModel : BaseDatabaseViewModel
	{
		private readonly IDealerRepository _dealerService;

		[Reactive]
		public IEnumerable<Dealer> Dealers { get; private set; } = Enumerable.Empty<Dealer>();

		public DealersViewModel(IDealerRepository dealerService, IAppLoginStateService appLoginState) : base(appLoginState)
		{
			_dealerService = dealerService;
		}

		protected override async Task LoadAsync()
		{
			Dealers = await _dealerService.GetAllDealersAsync();
		}

		protected override void UpdateUIForUser(User? user)
		{
			
		}
	}
}
