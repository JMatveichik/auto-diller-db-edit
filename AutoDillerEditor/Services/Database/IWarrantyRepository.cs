using AutoLandProcessor.Models;

namespace AutoLandProcessor.Services
{
    internal interface IWarrantyRepository
    {
		Task<IEnumerable<Warranty>> GetAllWarrantiesAsync();
	}
}
