using AutoLandProcessor.Data;
using AutoLandProcessor.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AutoLandProcessor.Services
{
	public class UserRepository : BaseRepository , IUserRepository
	{
		public UserRepository(AppDBContext context) : base(context) { }

		/// <summary>
		/// Get all users from database
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<User>> GetAllAsync()
		{
			return await _context.Users.ToListAsync();
		}

		/// <summary>
		/// Get user by ID
		/// </summary>
		/// <param name="id">User ID</param>
		/// <returns>User from database or null if not found</returns>
		public async Task<User?> GetByIdAsync(int id)
		{
			return await _context.Users.FindAsync(id);
		}

		/// <summary>
		/// Add new user to database
		/// </summary>
		/// <param name="user">New user to add</param>
		/// <returns></returns>
		public async Task CreateAsync(User user)
		{
			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Update user information in database
		/// </summary>
		/// <param name="user">User for update</param>
		/// <returns></returns>
		public async Task UpdateAsync(User user)
		{
			_context.Users.Update(user);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Implement user deletion from the database
		/// </summary>
		/// <param name="user">User for deletion</param>
		/// <returns></returns>
		public async Task DeleteAsync(User user)
		{
			if (user != null)
			{
				_context.Users.Remove(user);
				await _context.SaveChangesAsync();
			}
		}

		//USER SPECIFIED METHODS

		/// <summary>
		/// Try to found user in database for login in application
		/// </summary>
		/// <param name="credentials">User credetials</param>
		/// <returns>Return logged user if succsess, null overwice</returns>
		public async Task<User?> LoginUser(NetworkCredential credentials)
		{
			var foundUser = await _context.Users
				.FirstOrDefaultAsync(u => u.Login == credentials.UserName && u.Password == credentials.Password);

			return foundUser;
		}

		/// <summary>
		/// Search users in database with provided filters
		/// </summary>
		/// <param name="filter">Text filter to find user by Name, Surname or email</param>
		/// <param name="role">Role filter for user</param>
		/// <returns>IEnumerable list of users</returns>
		public async Task<IEnumerable<User>> FindAsync(string filter, string role)
		{
			var query = _context.Users.AsQueryable();

			// Поиск по тексту (если filter не пустой)
			if (!string.IsNullOrEmpty(filter))
			{
				query = query.Where(u =>
					u.Login.Contains(filter) ||
					u.Name.Contains(filter) ||
					u.Surname.Contains(filter) ||
					u.Email.Contains(filter)
				);
			}

			// Фильтр по роли (если role не пустая)
			if (!string.IsNullOrEmpty(role))
			{
				query = query.Where(u => u.Role == role.ToLower());
			}

			return await query.ToListAsync();
		}
	}
}
