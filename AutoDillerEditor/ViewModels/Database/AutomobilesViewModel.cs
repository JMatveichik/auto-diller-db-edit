using AutoLandProcessor.Models;
using AutoLandProcessor.Services;

namespace AutoLandProcessor.ViewModels
{
	public class AutomobilesViewModel : DatabaseViewModelBase<Automobile>
	{
		private readonly IAutomobileRepository _automobileRepository;


		public AutomobilesViewModel(IRepositoryFactory factory,
									IAppLoginStateService appLoginState)
									: base(factory.Automobiles, appLoginState)
		{
			_automobileRepository = factory.Automobiles;
		}

		protected override Task<Automobile?> ShowAddDialogAsync()
		{
			throw new NotImplementedException();
		}

		protected override Task<bool> ShowDeleteConfirmAsync(Automobile model)
		{
			throw new NotImplementedException();
		}

		protected override Task<bool> ShowEditDialogAsync(Automobile model)
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

