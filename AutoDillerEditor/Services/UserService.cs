using AutoLandProcessor.Data;
using AutoLandProcessor.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoLandProcessor.Services
{
	internal class UserService : DatabaseServiceBase , IUserService
	{

		public UserService(AppDatabaseContext context) : base(context) { }


		public async Task<IEnumerable<User>> GetAllUsersAsync()
		{
			return await _context.Users.ToListAsync();
		}

		public async Task<User> LoginUser(User user)
		{
			if (string.IsNullOrEmpty(user.Login) || string.IsNullOrEmpty(user.Password))
			{
				return null;
			}

			var foundUser = await _context.Users
				.FirstOrDefaultAsync(u => u.Login == user.Login && u.Password == user.Password);

			return foundUser;
		}

		public async Task<User> GetUserByIdAsync(int id)
		{
			return await _context.Users.FindAsync(id);
		}

		public async Task<User> GetUserByLoginAsync(string login)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
		}

		public async Task CreateUserAsync(User user)
		{
			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateUserAsync(User user)
		{
			_context.Users.Update(user);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteUserAsync(int id)
		{
			var user = await _context.Users.FindAsync(id);
			if (user != null)
			{
				_context.Users.Remove(user);
				await _context.SaveChangesAsync();
			}
		}
	}
}
