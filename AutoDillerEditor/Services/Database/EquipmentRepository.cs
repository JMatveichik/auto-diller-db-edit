using AutoLandProcessor.Data;
using AutoLandProcessor.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoLandProcessor.Services
{
	public class EquipmentRepository : BaseRepository, IEquipmentRepository
	{
		public EquipmentRepository(AppDBContext context) : base(context)
		{
		}

		public async Task<IEnumerable<Equipment>> GetAllDealersAsync()
		{
			return await _context.Equipments.ToListAsync();
		}
	}
}
