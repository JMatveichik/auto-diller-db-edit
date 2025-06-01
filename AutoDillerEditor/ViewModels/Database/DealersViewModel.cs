using AutoLandProcessor.Models;
using AutoLandProcessor.Services;

namespace AutoLandProcessor.ViewModels
{
    public class DealersViewModel : DatabaseViewModelBase<Dealer>
	{
		private readonly IDealerRepository _dealerRepository;


		public DealersViewModel( IRepositoryFactory factory,
								 IAppLoginStateService appLoginState)
								 : base(factory.Dealers, appLoginState)
		{
			_dealerRepository = factory.Dealers;
		}

		protected override Task<Dealer?> ShowAddDialogAsync()
		{
			throw new NotImplementedException();
		}

		protected override Task<bool> ShowDeleteConfirmAsync(Dealer model)
		{
			throw new NotImplementedException();
		}

		protected override Task<bool> ShowEditDialogAsync(Dealer model)
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
