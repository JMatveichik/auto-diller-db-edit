using AutoLandProcessor.Models;

namespace AutoLandProcessor.Services
{
    public interface IAutomobileRepository : IAutolandRepository<Automobile>
    {
		Task<IEnumerable<Automobile>> GetByBodyTypeAsync(int bodyTypeId);
	}
}
