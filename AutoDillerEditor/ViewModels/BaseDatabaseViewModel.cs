using AutoLandProcessor.Services;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace AutoLandProcessor.ViewModels
{
	internal abstract class BaseDatabaseViewModel : ViewModelBase
	{
		public ReactiveCommand<Unit, Unit> Load { get; private set; }

		public BaseDatabaseViewModel(IAppLoginStateService appLoginState) : base(appLoginState)
		{
			Load = ReactiveCommand.CreateFromTask(LoadAsync);
		}

		protected abstract Task LoadAsync();

	}
}
