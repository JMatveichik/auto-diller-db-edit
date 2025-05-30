using AutoLandProcessor.Services;
using ReactiveUI;
using System.Reactive;

namespace AutoLandProcessor.ViewModels
{
	public abstract class BaseDatabaseViewModel : ViewModelBase
	{
		public ReactiveCommand<Unit, Unit> Load { get; private set; }

		public BaseDatabaseViewModel(IAppLoginStateService appLoginState) : base(appLoginState)
		{
			Load = ReactiveCommand.CreateFromTask(LoadAsync);
		}

		protected abstract Task LoadAsync();

	}
}
