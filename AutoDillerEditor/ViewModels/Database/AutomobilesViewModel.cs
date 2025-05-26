using AutoLandProcessor.Models;
using AutoLandProcessor.Services;
using ReactiveUI.Fody.Helpers;


namespace AutoLandProcessor.ViewModels
{
	internal class AutomobilesViewModel : BaseDatabaseViewModel
	{
		private readonly IAutomobileService _automobileService;

		[Reactive]
		public IEnumerable<Automobile> Automobiles { get; private set; } = Enumerable.Empty<Automobile>();


		public AutomobilesViewModel(IAutomobileService automobileService, IAppLoginStateService appLoginState) : base(appLoginState)
		{
			_automobileService = automobileService;
		}

		protected override async Task LoadAsync()
		{
			Automobiles = await _automobileService.GetAllAutomobilesAsync();
		}

		protected override void UpdateUIForUser(User? user)
		{

		}
	}
}

