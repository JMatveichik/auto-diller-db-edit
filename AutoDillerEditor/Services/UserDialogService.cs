using AutoLandProcessor.Models;
using AutoLandProcessor.ViewModels;
using AutoLandProcessor.Views;


namespace AutoLandProcessor.Services
{
	public class UserDialogService : IUserDialogService
	{
		public Task<User?> ShowAddNewUserDialog()
		{
			// Создаем нового пользователя с дефолтными значениями
			var newUser = new User();

			var dialog = new EditUserDialog(newUser);
			dialog.Title = "ADD NEW USER";

			if (dialog.ShowDialog() == true)
			{
				return Task.FromResult<User?>(newUser);
			}

			return Task.FromResult<User?>(null);
		}
		public Task<bool> ShowEditUserDialog(User user)
		{
			var userCopy = user.Clone();

			var dialog = new EditUserDialog(userCopy);
			dialog.Title = "EDIT USER DATA";

			if (dialog.ShowDialog() == true)
			{
				user.CopyFrom(userCopy);
				return Task.FromResult(true);
			}

			return Task.FromResult(false);
		}

		public Task<bool> ShowDeleteUserDialog(User user)
		{
			string title = "DELETE USER";
			string body = $"Are you sure whant delete user {user.Name} {user.Surname} from database?";
			var messageModel = new DialogMessageViewModel(title, body);

			var dialog = new ConfirmDialog(messageModel);
			return Task.FromResult(dialog.ShowDialog() == true);
		}
	}
}
