using AutoLandProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLandProcessor.Services
{
	internal interface IUserService
	{
		Task<IEnumerable<User>> GetAllUsersAsync();
		Task<User> GetUserByIdAsync(int id);
		Task<User> GetUserByLoginAsync(string login);
		Task CreateUserAsync(User user);
		Task UpdateUserAsync(User user);
		Task DeleteUserAsync(int id);
	}
}
