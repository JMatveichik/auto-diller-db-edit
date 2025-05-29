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
		private readonly IUserRepository _userRepository;

		private readonly IUserDialogService _dialogs;

		[Reactive]
		public IEnumerable<User> Users { get; private set; } = Enumerable.Empty<User>();

		[Reactive]
		public User? SelectedUser { get; set; } = null;

		[Reactive]
		public string TextFilter { get; set; } = string.Empty;

		[Reactive]
		public string RoleFilter { get; set; } = string.Empty;

		public static List<string> AvailableRoles { get; private set; } = new() { "Admin", "User", "Employee" };

		/// <summary>
		///Команда редактирования пользователя
		/// </summary>
		public ReactiveCommand<User, Unit> EditUserCommand { get; private set; }

		/// <summary>
		///Команда удаления пользователя
		/// </summary>
		public ReactiveCommand<User, Unit> DeleteUserCommand { get; private set; }

		/// <summary>
		///Команда добавления нового пользователя
		/// </summary>
		public ReactiveCommand<Unit, Unit> AddUserCommand { get; private set; }


		public UsersViewModel(	IUserRepository userRepository,
								IUserDialogService dialogs,
								IAppLoginStateService appLoginState) : base(appLoginState)
		{
			_userRepository = userRepository;
			_dialogs = dialogs;

			//Observable для текстового фильтра
			var searchStream = this.WhenAnyValue(x => x.TextFilter)
				.Throttle(TimeSpan.FromMilliseconds(500))
				.Where(text => text?.Length >= 3 || string.IsNullOrEmpty(text));

			//Observable для фильтра по ролям
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
			AddUserCommand	    = ReactiveCommand.CreateFromTask(AddUser);
		}

		protected override async Task LoadAsync()
		{
			Users = await _userRepository.GetAllAsync();
		}

		protected async Task<IEnumerable<User>> SearchUsersAsync(string filter, string role)
		{
			return await _userRepository.FindAsync(filter, role);
		}

		private async Task AddUser()
		{
			var newUser = await _dialogs.ShowAddNewUserDialog();
			if (newUser != null)
			{
				await _userRepository.CreateAsync(newUser);
				await LoadAsync();
			}
		}

		private async Task EditUser(User user)
		{
			if (await _dialogs.ShowEditUserDialog(user))
			{
				await _userRepository.UpdateAsync(user);
				await LoadAsync();
			}
		}

		private async Task DeleteUser(User user)
		{
			if (await _dialogs.ShowDeleteUserDialog(user))
			{
				await _userRepository.DeleteAsync(user);
				await LoadAsync();
			}
		}

		protected override void UpdateUIForUser(User? user)
		{
		}
	}
}

