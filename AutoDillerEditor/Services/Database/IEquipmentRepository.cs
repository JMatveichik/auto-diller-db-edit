using AutoLandProcessor.Models;

namespace AutoLandProcessor.Services
{
	public interface IEquipmentRepository
	{
		Task<IEnumerable<Equipment>> GetAllDealersAsync();
	}
}
