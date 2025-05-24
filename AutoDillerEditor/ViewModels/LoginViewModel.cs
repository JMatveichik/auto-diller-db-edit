using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using AutoLandProcessor.Models;
using AutoLandProcessor.Services;
using System.Windows.Input;
using System.Reactive;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;

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

		public ReactiveCommand<Unit, User?> LoginCommand { get; }

		public LoginViewModel(IUserService userService, IAppLoginStateService appLoginState) : base(appLoginState)
		{
			_userService = userService ??
				throw new ArgumentNullException(nameof(userService));

			LoginCommand = ReactiveCommand.CreateFromTask (ExecuteLogin);
		}

		private async Task<User?> ExecuteLogin()
		{
			if (string.IsNullOrEmpty(Login) || string.IsNullOrEmpty(Password))
			{
				ErrorMessage = "Логин и пароль обязательны";
				return null;
			}

			try
			{
				return await _userService.LoginUser(new User { Login = Login, Password = Password });
			}
			catch (Exception ex)
			{
				ErrorMessage = $"Ошибка входа: {ex.Message}";
				return null;
			}
		}

		protected override void UpdateUIForUser(User? user)
		{

		}
	}
}

