using AutoLandProcessor.Data;
using AutoLandProcessor.Models;

namespace AutoLandProcessor.Services
{
	public class ContractRepository : BaseRepository<Contract>, IContractRepository
	{
		public ContractRepository(AppDBContext context) : base(context)
		{
		}


	}
}
