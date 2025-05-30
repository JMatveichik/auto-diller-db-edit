
namespace AutoLandProcessor.Services
{
	/// <summary>
	/// Base interface for working with Autoland database entities
	/// </summary>
	/// <typeparam name="TModel">Entity type</typeparam>
	public interface IAutolandRepository<TModel> where TModel : class
	{
		/// <summary>
		/// Recieve all entities from database async
		/// </summary>
		/// <returns>IEnumerable list specified on model type</returns>
		Task<IEnumerable<TModel>> GetAllAsync();

		/// <summary>
		/// Return entity for provided primary key
		/// </summary>
		/// <param name="id">Primary key in entity table</param>
		/// <returns>Database entity if present or null owervice</returns>
		Task<TModel?> GetByIdAsync(int id);

		/// <summary>
		/// Add new entity to database
		/// </summary>
		/// <param name="item">Entity for add</param>
		/// <returns></returns>
		Task CreateAsync(TModel item);

		/// <summary>
		/// Update existing database entity
		/// </summary>
		/// <param name="item">Entity for update</param>
		/// <returns></returns>
		Task UpdateAsync(TModel item);

		/// <summary>
		/// Delete provided entity from database
		/// </summary>
		/// <param name="item">Entity for deletion</param>
		/// <returns></returns>
		Task DeleteAsync(TModel item);
	}
}
