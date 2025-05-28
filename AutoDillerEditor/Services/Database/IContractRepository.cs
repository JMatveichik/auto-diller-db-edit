using AutoLandProcessor.Models;

namespace AutoLandProcessor.Services
{
    internal interface IContractRepository
    {
		Task<IEnumerable<Contract>> GetAllContractsAsync();
	}
}
