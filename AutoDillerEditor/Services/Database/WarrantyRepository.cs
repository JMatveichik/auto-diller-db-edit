using AutoLandProcessor.Data;
using AutoLandProcessor.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoLandProcessor.Services
{
	public class WarrantyRepository : BaseRepository, IWarrantyRepository
	{
		public WarrantyRepository(AppDBContext context) : base(context)
		{
		}

		public async Task<IEnumerable<Warranty>> GetAllWarrantiesAsync()
		{
			return await _context.Warranties.ToListAsync();
		}
	}
}
