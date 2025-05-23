using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive;
using AutoLandProcessor.Models;
using AutoLandProcessor.Services;

namespace AutoLandProcessor.ViewModels
{
    internal class UsersViewModel : BaseDatabaseViewModel
    {
		private readonly IUserService _userService;

		[Reactive]
		public IEnumerable<User> Users { get; private set; } = Enumerable.Empty<User>();


		public UsersViewModel(IUserService userService) : base()
		{
			_userService = userService;
			// Автоматическая загрузка при инициализации
			LoadAsync().ConfigureAwait(false);

		}

		protected override async Task LoadAsync()
		{
			Users = await _userService.GetAllUsersAsync();
		}
	}
}

