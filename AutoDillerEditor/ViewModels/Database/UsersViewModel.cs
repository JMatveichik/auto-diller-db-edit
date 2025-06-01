using AutoLandProcessor.Models;
using AutoLandProcessor.Services;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using System.Reactive.Linq;

namespace AutoLandProcessor.ViewModels
{
	public class UsersViewModel : DatabaseViewModelBase<User>
	{
		#region Private fields

		private readonly IUserRepository _userRepository;
		private readonly IUserDialogService _dialogs;

		#endregion

		#region Public properties
		[Reactive]
		public string TextFilter { get; set; } = string.Empty;

		[Reactive]
		public string RoleFilter { get; set; } = string.Empty;

		public static List<string> AvailableRoles { get; } = new() { "Admin", "User", "Employee" };

		#endregion

		#region Constructors
		public UsersViewModel(	IRepositoryFactory factory,
								IUserDialogService dialogs,
								IAppLoginStateService appLoginState)
								: base(factory.Users, appLoginState)
		{
			_userRepository = factory.Users;
			_dialogs = dialogs;

			// Автоматический фильтр по тексту и роли
			this.WhenAnyValue(x => x.TextFilter, x => x.RoleFilter)
				.Throttle(TimeSpan.FromMilliseconds(300))
				.DistinctUntilChanged()
				.Where(x => x.Item1.Length >= 3 || string.IsNullOrEmpty(x.Item1))
				.ObserveOn(RxApp.MainThreadScheduler)
				.Subscribe(async filters =>
				{
					Items = await _userRepository.FindAsync(filters.Item1, filters.Item2);
				});
		}

		#endregion

		#region User Dialogs
		protected override Task<User?> ShowAddDialogAsync() =>
			_dialogs.ShowAddNewUserDialog();

		protected override Task<bool> ShowEditDialogAsync(User model) =>
			_dialogs.ShowEditUserDialog(model);

		protected override Task<bool> ShowDeleteConfirmAsync(User model) =>
			_dialogs.ShowDeleteUserDialog(model);

		#endregion

		protected override void UpdateUIForUser(User? user)
		{
			if (user != null)
			{

			}
		}
	}
}
