using AutoLandProcessor.Data;
using AutoLandProcessor.Models;
using Microsoft.EntityFrameworkCore;

namespace AutoLandProcessor.Services
{
	public class EquipmentRepository : BaseRepository<Equipment>, IEquipmentRepository
	{
		public EquipmentRepository(AppDBContext context) : base(context)
		{
		}
	}
}
