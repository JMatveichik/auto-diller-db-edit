using ReactiveUI;
using System.Reactive.Linq;
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

		[Reactive]
		public string TextFilter { get; set; } = string.Empty;

		[Reactive]
		public string RoleFilter { get; set; } = string.Empty;

		[Reactive]
		public List<string> AvailableRoles { get; private set; } = new() { "Admin", "User", "Employee" };

		/// <summary>
		///Команда редактирования пользователя
		/// </summary>
		public ReactiveCommand<User, Unit> EditUserCommand { get; private set; }

		/// <summary>
		///Команда удаления пользователя
		/// </summary>
		public ReactiveCommand<User, Unit> DeleteUserCommand { get; private set; }


		public UsersViewModel(IUserRepository userService, IAppLoginStateService appLoginState) : base(appLoginState)
		{
			_userService = userService;

			var searchStream = this.WhenAnyValue(x => x.TextFilter)
				.Throttle(TimeSpan.FromMilliseconds(500))
				.Where(text => text?.Length >= 3 || string.IsNullOrEmpty(text));

			var roleStream = this.WhenAnyValue(x => x.RoleFilter);

			// Объединяем два Observable от текстового фильтра и филтра по ролям
			searchStream
				.Merge(roleStream)
				.ObserveOn(RxApp.MainThreadScheduler)
				.Subscribe(async _ =>
				{
					Users = await SearchUsersAsync(TextFilter, RoleFilter);
				});

			EditUserCommand		= ReactiveCommand.CreateFromTask<User>(EditUser);
			DeleteUserCommand	= ReactiveCommand.CreateFromTask<User>(DeleteUser);

		}

		protected override async Task LoadAsync()
		{
			Users = await _userService.GetAllAsync();
		}

		protected async Task<IEnumerable<User>> SearchUsersAsync(string filter, string role)
		{
			return await _userService.FindAsync(filter, role);
		}

		private async Task EditUser(User user)
		{
			await _userService.UpdateAsync(user);
		}

		private async Task DeleteUser(User user)
		{
			await _userService.DeleteAsync(user);
		}


		protected override void UpdateUIForUser(User? user)
		{
		}
	}
}

