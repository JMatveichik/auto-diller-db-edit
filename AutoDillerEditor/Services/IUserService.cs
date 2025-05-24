using AutoLandProcessor.Models;


namespace AutoLandProcessor.Services
{
	internal interface IUserService
	{
		Task<IEnumerable<User>> GetAllUsersAsync();

		Task<User> LoginUser(User user );

		Task<User> GetUserByIdAsync(int id);
		Task<User> GetUserByLoginAsync(string login);
		Task CreateUserAsync(User user);
		Task UpdateUserAsync(User user);
		Task DeleteUserAsync(int id);

	}
}
