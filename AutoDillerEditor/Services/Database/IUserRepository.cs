using AutoLandProcessor.Models;
using System.Net;


namespace AutoLandProcessor.Services
{
	public interface IUserRepository : IAutolandRepository<User>
	{
		Task<User?> LoginUser(NetworkCredential credentials);

		Task<IEnumerable<User>> FindAsync(string filter, string role);
	}
}
