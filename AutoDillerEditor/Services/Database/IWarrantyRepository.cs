using AutoLandProcessor.Models;

namespace AutoLandProcessor.Services
{
    public interface IWarrantyRepository
    {
		Task<IEnumerable<Warranty>> GetAllWarrantiesAsync();
	}
}
