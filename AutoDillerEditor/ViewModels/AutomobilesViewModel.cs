using AutoLandProcessor.Models;
using AutoLandProcessor.Services;
using ReactiveUI.Fody.Helpers;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace AutoLandProcessor.ViewModels
{
	internal class AutomobilesViewModel : BaseDatabaseViewModel
	{
		private readonly IAutomobileService _automobileService;

		[Reactive]
		public IEnumerable<Automobile> Automobiles { get; private set; } = Enumerable.Empty<Automobile>();


		public AutomobilesViewModel(IAutomobileService automobileService) : base()
		{
			_automobileService = automobileService;

			// Автоматическая загрузка при инициализации
			LoadAsync().ConfigureAwait(false);

		}

		protected override async Task LoadAsync()
		{
			Automobiles = await _automobileService.GetAllAutomobilesAsync();
		}
	}
}

