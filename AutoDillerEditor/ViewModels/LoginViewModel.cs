using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using AutoLandProcessor.Models;
using AutoLandProcessor.Services;
using System.Windows.Input;
using System.Reactive;

namespace AutoLandProcessor.ViewModels
{
	internal class LoginViewModel : ViewModelBase
	{
		private readonly IUserService _userService;

		[Reactive]
		public string Login{ get; set; } = string.Empty;

		[Reactive]
		public string Password { get; set; } = string.Empty;


		[Reactive]
		public string ErrorMessage { get; set; } = string.Empty;

		public ReactiveCommand<Unit, Unit> LoginCommand { get; }

		public LoginViewModel(IUserService userService)
		{
			_userService = userService ?? throw new ArgumentNullException(nameof(userService));
			LoginCommand = ReactiveCommand.CreateFromTask (ExecuteLogin);
		}

		private async Task ExecuteLogin()
		{
			ErrorMessage = string.Empty;

			if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
			{
				ErrorMessage = "Логин и пароль обязательны для заполнения";
				return;
			}

			var user = new User { Login = Login, Password = Password };
			var authenticatedUser = await _userService.LoginUser(user);

			if (authenticatedUser == null)
			{
				ErrorMessage = "Неверный логин или пароль";
				return;
			}

			// Здесь можно перейти к главному окну приложения
			// Например, через Messenger или NavigationService
		}
	}
}

