using AutoLandProcessor.Models;


namespace AutoLandProcessor.Services
{
    public interface IDealerRepository
    {
		Task<IEnumerable<Dealer>> GetAllDealersAsync();
	}
}
