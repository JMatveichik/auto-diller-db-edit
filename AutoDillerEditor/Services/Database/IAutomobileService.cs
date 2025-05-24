using AutoLandProcessor.Models;

namespace AutoLandProcessor.Services
{
	internal interface IAutomobileService
	{
		Task<IEnumerable<Automobile>> GetAllAutomobilesAsync();
	}
}
