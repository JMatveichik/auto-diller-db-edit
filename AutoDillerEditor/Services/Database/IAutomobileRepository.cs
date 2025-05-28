using AutoLandProcessor.Models;

namespace AutoLandProcessor.Services
{
	internal interface IAutomobileRepository
	{
		Task<IEnumerable<Automobile>> GetAllAutomobilesAsync();
	}
}
