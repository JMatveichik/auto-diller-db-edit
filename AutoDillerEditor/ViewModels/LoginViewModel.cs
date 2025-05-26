using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using AutoLandProcessor.Models;
using AutoLandProcessor.Services;
using System.Reactive;
using System.Security;
using System.Net;
using System.Security.Principal;

namespace AutoLandProcessor.ViewModels
{
	internal class LoginViewModel : ViewModelBase
	{
		private readonly IUserService _userService;

		[Reactive]
		public string Username{ get; set; } = string.Empty;

		[Reactive]
		public SecureString Password { get; set; } = new();

		[Reactive]
		public string ErrorMessage { get; set; } = string.Empty;
		[Reactive]
		public bool IsLoginInProcess { get; private set; }

		public ReactiveCommand<Unit, Unit> LoginCommand { get; private set; }


		public LoginViewModel(IUserService userService, IAppLoginStateService appLoginState) : base(appLoginState)
		{

			_userService = userService ??
				throw new ArgumentNullException(nameof(userService));


			var canLogin = this.WhenAnyValue(
				x => x.Username,
				x => x.Password,
				(username, password) =>
					!string.IsNullOrWhiteSpace(username) &&
					username.Length > 3 && password.Length > 3
			);

			LoginCommand = ReactiveCommand.CreateFromTask (ExecuteLogin,  canLogin);
		}

		private async Task ExecuteLogin()
		{
			try
			{
				IsLoginInProcess = true;
				ErrorMessage = "Авторизация...";

				await Task.Delay(3000);

				// Устанавливаем пользователя через сервис
				_appLoginState.CurrentUser = await _userService.LoginUser(new NetworkCredential(Username, Password));

				if (CurrentUser != null)
				{
					Thread.CurrentPrincipal = new GenericPrincipal(
						new GenericIdentity(CurrentUser.Login!), new[] { CurrentUser.Role! });

					ErrorMessage = string.Empty;
				}
				else
				{
					ErrorMessage = $"Ошибка входа {Username}: Неверное сочетание логин - пароль";
				}
			}
			catch (Exception ex)
			{
				ErrorMessage = $"Ошибка входа: {ex.Message}";
			}
			finally {
				IsLoginInProcess = false;
			}
		}

		protected override void UpdateUIForUser(User? user)
		{

		}
	}
}

