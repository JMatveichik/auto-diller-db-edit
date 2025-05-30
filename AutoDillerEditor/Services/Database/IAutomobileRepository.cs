using AutoLandProcessor.Models;

namespace AutoLandProcessor.Services
{
	public interface IAutomobileRepository
	{
		Task<IEnumerable<Automobile>> GetAllAutomobilesAsync();
	}
}
