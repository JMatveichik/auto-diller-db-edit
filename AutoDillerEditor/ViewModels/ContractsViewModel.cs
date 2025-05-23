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
	internal class ContractsViewModel : BaseDatabaseViewModel
	{
		private readonly IContractService _contractService;

		[Reactive]
		public IEnumerable<Contract> Contracts { get; private set; } = Enumerable.Empty<Contract>();

		public ContractsViewModel(IContractService contractService) : base()
		{
			_contractService = contractService;
			LoadAsync().ConfigureAwait(false);

		}
		protected override async Task LoadAsync()
		{
			Contracts = await _contractService.GetAllContractsAsync();
		}
	}
}
