using AutoLandProcessor.Models;


namespace AutoLandProcessor.Services
{
    internal interface IDealerRepository
    {
		Task<IEnumerable<Dealer>> GetAllDealersAsync();
	}
}
