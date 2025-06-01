using AutoLandProcessor.Data;
using AutoLandProcessor.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoLandProcessor.Services
{
	public class AutomobileRepository : BaseRepository<Automobile>, IAutomobileRepository
	{

		public AutomobileRepository(AppDBContext context) : base(context)
		{

		}

		public async Task<IEnumerable<Automobile>> GetByBodyTypeAsync(int bodyTypeId)
		{
			return await _dbSet.Where(a => a.BodyTypeId == bodyTypeId).ToListAsync();
		}
	}
}
