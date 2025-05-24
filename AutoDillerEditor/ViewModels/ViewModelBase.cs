using AutoLandProcessor.Models;
using AutoLandProcessor.Services;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace AutoLandProcessor.ViewModels
{
	internal abstract class ViewModelBase : ReactiveObject
	{
		[Reactive]
		public User? CurrentUser { get; protected set; }

		[Reactive]
		public bool IsAuthenticated { get; private set; }

		public ViewModelBase(IAppLoginStateService appLoginStateService)
		{
			appLoginStateService.UserChanged.Subscribe(user =>
			{
				CurrentUser = user;
				IsAuthenticated = CurrentUser != null;

				UpdateUIForUser(user);
			});
		}

		protected abstract void UpdateUIForUser(User? user);
	}
}
