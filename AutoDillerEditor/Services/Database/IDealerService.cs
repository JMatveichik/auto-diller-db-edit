using AutoLandProcessor.Models;


namespace AutoLandProcessor.Services
{
    internal interface IDealerService
    {
		Task<IEnumerable<Dealer>> GetAllDealersAsync();
	}
}
