using AutoLandProcessor.Models;
using AutoLandProcessor.Services;
using ReactiveUI.Fody.Helpers;


namespace AutoLandProcessor.ViewModels
{
    internal class DealersViewModel : BaseDatabaseViewModel
	{
		private readonly IDealerService _dealerService;

		[Reactive]
		public IEnumerable<Dealer> Dealers { get; private set; } = Enumerable.Empty<Dealer>();

		public DealersViewModel(IDealerService dealerService) : base()
		{
			_dealerService = dealerService;
			// Автоматическая загрузка при инициализации
			LoadAsync().ConfigureAwait(false);

		}

		protected override async Task LoadAsync()
		{
			Dealers = await _dealerService.GetAllDealersAsync();
		}
	}
}
