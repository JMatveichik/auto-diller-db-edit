using AutoLandProcessor.Data;
using AutoLandProcessor.Models;
using Microsoft.EntityFrameworkCore;


namespace AutoLandProcessor.Services
{
	public class DealerRepository : BaseRepository,  IDealerRepository
	{
		public DealerRepository(AppDBContext context) : base(context) { }

		public async Task<IEnumerable<Dealer>> GetAllDealersAsync()
		{
			return await _context.Dealers.ToListAsync();
		}
	}
}
