using AutoLandProcessor.Data;
using AutoLandProcessor.Models;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace AutoLandProcessor.Services
{
	public class UserRepository : BaseRepository , IUserRepository
	{
		public UserRepository(AppDBContext context) : base(context) { }

		public async Task<IEnumerable<User>> GetAllAsync()
		{
			return await _context.Users.ToListAsync();
		}

		public async Task<User?> LoginUser(NetworkCredential credentials)
		{
			var foundUser = await _context.Users
				.FirstOrDefaultAsync(u => u.Login == credentials.UserName && u.Password == credentials.Password	);

			return foundUser;
		}

		public async Task<User?> GetByIdAsync(int id)
		{
			return await _context.Users.FindAsync(id);
		}

		public async Task<User?> GetUserByLoginAsync(string login)
		{
			return await _context.Users.FirstOrDefaultAsync(u => u.Login == login);
		}

		public async Task CreateAsync(User user)
		{
			await _context.Users.AddAsync(user);
			await _context.SaveChangesAsync();
		}

		public async Task UpdateAsync(User user)
		{
			_context.Users.Update(user);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(User user)
		{
			if (user != null)
			{
				_context.Users.Remove(user);
				await _context.SaveChangesAsync();
			}
		}

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
