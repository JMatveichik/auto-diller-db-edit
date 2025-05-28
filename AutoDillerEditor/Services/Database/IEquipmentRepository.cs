using AutoLandProcessor.Models;

namespace AutoLandProcessor.Services
{
	internal interface IEquipmentRepository
	{
		Task<IEnumerable<Equipment>> GetAllDealersAsync();
	}
}
