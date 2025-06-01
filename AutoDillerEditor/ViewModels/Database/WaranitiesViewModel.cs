using AutoLandProcessor.Models;
using AutoLandProcessor.Services;

namespace AutoLandProcessor.ViewModels
{
    public class WarrantiesViewModel : DatabaseViewModelBase<Warranty>
	{
		private readonly IWarrantyRepository _warrantyRepository;

		public WarrantiesViewModel(IRepositoryFactory factory,
								 IAppLoginStateService appLoginState)
								 : base(factory.Warranties, appLoginState)
		{
			_warrantyRepository = factory.Warranties;
		}

		protected override Task<Warranty?> ShowAddDialogAsync()
		{
			throw new NotImplementedException();
		}

		protected override Task<bool> ShowDeleteConfirmAsync(Warranty model)
		{
			throw new NotImplementedException();
		}

		protected override Task<bool> ShowEditDialogAsync(Warranty model)
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
