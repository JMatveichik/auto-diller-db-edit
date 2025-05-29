using AutoLandProcessor.Models;

namespace AutoLandProcessor.Services
{
	internal interface IUserDialogService
	{
		Task<User?> ShowAddNewUserDialog();

		Task<bool> ShowEditUserDialog(User user);

		Task<bool> ShowDeleteUserDialog(User user);
	}
}
