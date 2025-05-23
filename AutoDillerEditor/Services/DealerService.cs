using AutoLandProcessor.Data;
using AutoLandProcessor.Models;
using Microsoft.EntityFrameworkCore;


namespace AutoLandProcessor.Services
{
	internal class DealerService : DatabaseServiceBase,  IDealerService
	{
		public DealerService(AppDatabaseContext context) : base(context) { }

		public async Task<IEnumerable<Dealer>> GetAllDealersAsync()
		{
			return await _context.Dealers.ToListAsync();
		}
	}
}
