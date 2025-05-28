using AutoLandProcessor.Models;
using AutoLandProcessor.Services;
using ReactiveUI.Fody.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLandProcessor.ViewModels
{
	internal class EquipmentsViewModel : BaseDatabaseViewModel
	{
		private readonly IEquipmentRepository _equipService;

		[Reactive]
		public IEnumerable<Equipment> Equipments { get; private set; } = Enumerable.Empty<Equipment>();

		public EquipmentsViewModel(IEquipmentRepository equipService, IAppLoginStateService appLoginState) : base(appLoginState)
		{
			_equipService = equipService;
		}

		protected override async Task LoadAsync()
		{
			Equipments = await _equipService.GetAllDealersAsync();
		}

		protected override void UpdateUIForUser(User? user)
		{

		}
	}
}