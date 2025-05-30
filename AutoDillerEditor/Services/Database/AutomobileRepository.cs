using AutoLandProcessor.Data;
using AutoLandProcessor.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoLandProcessor.Services
{
	public class AutomobileRepository : BaseRepository, IAutomobileRepository
	{

		public AutomobileRepository(AppDBContext context) : base(context)
		{

		}
		/// <summary>
		/// Get all Automobiles from database
		/// </summary>
		/// <returns></returns>
		public async Task<IEnumerable<Automobile>> GetAllAsync()
		{
			return await _context.Automobiles.ToListAsync();
		}

		/// <summary>
		/// Get Automobile by ID
		/// </summary>
		/// <param name="id">Automobile ID</param>
		/// <returns>Automobile from database or null if not found</returns>
		public async Task<Automobile?> GetByIdAsync(int id)
		{
			return await _context.Automobiles.FindAsync(id);
		}

		/// <summary>
		/// Add new Automobile to database
		/// </summary>
		/// <param name="Automobile">New Automobile to add</param>
		/// <returns></returns>
		public async Task CreateAsync(Automobile Automobile)
		{
			await _context.Automobiles.AddAsync(Automobile);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Update Automobile information in database
		/// </summary>
		/// <param name="Automobile">Automobile for update</param>
		/// <returns></returns>
		public async Task UpdateAsync(Automobile Automobile)
		{
			_context.Automobiles.Update(Automobile);
			await _context.SaveChangesAsync();
		}

		/// <summary>
		/// Implement Automobile deletion from the database
		/// </summary>
		/// <param name="Automobile">Automobile for deletion</param>
		/// <returns></returns>
		public async Task DeleteAsync(Automobile Automobile)
		{
			if (Automobile != null)
			{
				_context.Automobiles.Remove(Automobile);
				await _context.SaveChangesAsync();
			}
		}

	}
}
