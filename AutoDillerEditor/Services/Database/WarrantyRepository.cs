using AutoLandProcessor.Data;
using AutoLandProcessor.Models;


namespace AutoLandProcessor.Services
{
	public class WarrantyRepository : BaseRepository<Warranty>, IWarrantyRepository
	{
		public WarrantyRepository(AppDBContext context) : base(context)
		{
		}
	}
}
