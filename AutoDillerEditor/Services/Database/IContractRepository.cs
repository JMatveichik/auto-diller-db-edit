using AutoLandProcessor.Models;

namespace AutoLandProcessor.Services
{
    public interface IContractRepository
    {
		Task<IEnumerable<Contract>> GetAllContractsAsync();
	}
}
