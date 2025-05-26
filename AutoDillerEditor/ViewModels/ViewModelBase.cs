using AutoLandProcessor.Models;
using AutoLandProcessor.Services;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive.Linq;

namespace AutoLandProcessor.ViewModels
{
	internal abstract class ViewModelBase : ReactiveObject
	{
		protected readonly IAppLoginStateService _appLoginState;

		[ObservableAsProperty]
		public User? CurrentUser { get; } // Только для чтения

		[ObservableAsProperty]
		public bool IsAuthenticated { get; }

		public ViewModelBase(IAppLoginStateService appLoginStateService)
		{
			_appLoginState = appLoginStateService;

			// Преобразуем поток изменений пользователя в свойства
			_appLoginState.UserChanged
				.ToPropertyEx(this, x => x.CurrentUser);

			_appLoginState.UserChanged
				.Select(user => user != null)
				.ToPropertyEx(this, x => x.IsAuthenticated);

			_appLoginState.UserChanged
				.Subscribe(UpdateUIForUser);
		}

		protected abstract void UpdateUIForUser(User? user);
	}
}
