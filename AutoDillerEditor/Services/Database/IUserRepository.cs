using AutoLandProcessor.Models;
using System.Net;


namespace AutoLandProcessor.Services
{
	internal interface IUserRepository
	{
		Task<IEnumerable<User>> GetAllUsersAsync();

		Task<User?> LoginUser(NetworkCredential credentials);

		Task<User?> GetUserByIdAsync(int id);

		Task<User?> GetUserByLoginAsync(string login);

		Task CreateUserAsync(User user);

		Task UpdateUserAsync(User user);

		Task DeleteUserAsync(int id);
	}
}
