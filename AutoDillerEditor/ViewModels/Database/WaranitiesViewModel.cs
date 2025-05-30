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
    public class WarrantiesViewModel : BaseDatabaseViewModel
	{
		private readonly IWarrantyRepository _warrantyService;

		[Reactive]
		public IEnumerable<Warranty> Warranties { get; private set; } = Enumerable.Empty<Warranty>();

		[Reactive]
		public Warranty? SelectedWarranty { get; set; } = null;


		public WarrantiesViewModel(IWarrantyRepository warrantyService, IAppLoginStateService appLoginState) : base(appLoginState)
		{
			_warrantyService = warrantyService;
		}

		protected override async Task LoadAsync()
		{
			Warranties = await _warrantyService.GetAllWarrantiesAsync();
		}

		protected override void UpdateUIForUser(User? user)
		{
		}
	}
}
