using AutoLandProcessor.Models;
using AutoLandProcessor.Services;

namespace AutoLandProcessor.ViewModels
{
	public class EquipmentsViewModel : DatabaseViewModelBase<Equipment>
	{
		private readonly IEquipmentRepository _equipmentRepository;


		public EquipmentsViewModel(IRepositoryFactory factory,
								 IAppLoginStateService appLoginState)
								 : base(factory.Equipments, appLoginState)
		{
			_equipmentRepository = factory.Equipments;
		}

		protected override Task<Equipment?> ShowAddDialogAsync()
		{
			throw new NotImplementedException();
		}

		protected override Task<bool> ShowDeleteConfirmAsync(Equipment model)
		{
			throw new NotImplementedException();
		}

		protected override Task<bool> ShowEditDialogAsync(Equipment model)
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