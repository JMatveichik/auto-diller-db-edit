using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;
using AutoLandProcessor.Models;
using AutoLandProcessor.Services;

namespace AutoLandProcessor.ViewModels
{
    internal class UsersViewModel : BaseDatabaseViewModel
    {
		private readonly IUserRepository _userService;

		[Reactive]
		public IEnumerable<User> Users { get; private set; } = Enumerable.Empty<User>();

		[Reactive]
		public User? SelectedUser { get; set; } = null;


		public UsersViewModel(IUserRepository userService, IAppLoginStateService appLoginState) : base(appLoginState)
		{
			_userService = userService;
		}

		protected override async Task LoadAsync()
		{
			Users = await _userService.GetAllUsersAsync();
		}

		protected override void UpdateUIForUser(User? user)
		{
		}
	}
}

