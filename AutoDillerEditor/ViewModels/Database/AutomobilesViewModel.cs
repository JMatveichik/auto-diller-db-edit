using AutoLandProcessor.Models;
using AutoLandProcessor.Services;
using ReactiveUI.Fody.Helpers;


namespace AutoLandProcessor.ViewModels
{
	public class AutomobilesViewModel : BaseDatabaseViewModel
	{
		private readonly IAutomobileRepository _automobileService;

		[Reactive]
		public IEnumerable<Automobile> Automobiles { get; private set; } = Enumerable.Empty<Automobile>();


		public AutomobilesViewModel(IAutomobileRepository automobileService, IAppLoginStateService appLoginState) : base(appLoginState)
		{
			_automobileService = automobileService;
		}

		protected override async Task LoadAsync()
		{
			Automobiles = await _automobileService.GetAllAsync();
		}

		protected override void UpdateUIForUser(User? user)
		{

		}
	}
}

