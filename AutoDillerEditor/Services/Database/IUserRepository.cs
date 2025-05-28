using AutoLandProcessor.Models;
using System.Net;


namespace AutoLandProcessor.Services
{
	internal interface IAutolandRepository<TModel> where TModel : class
	{
		Task<IEnumerable<TModel>> GetAllAsync();

		Task<TModel?> GetByIdAsync(int id);

		Task CreateAsync(TModel item);

		Task UpdateAsync(TModel item);

		Task DeleteAsync(TModel item);
	}

	internal interface IUserRepository : IAutolandRepository<User>
	{
		Task<User?> LoginUser(NetworkCredential credentials);

		Task<IEnumerable<User>> FindAsync(string filter, string role);
	}
}
