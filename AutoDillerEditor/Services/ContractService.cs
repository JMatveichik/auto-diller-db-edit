using AutoLandProcessor.Data;
using AutoLandProcessor.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLandProcessor.Services
{
	internal class ContractService : DatabaseServiceBase, IContractService
	{
		public ContractService(AppDatabaseContext context) : base(context)
		{
		}

		public async Task<IEnumerable<Contract>> GetAllContractsAsync()
		{
			return await _context.Contracts.ToListAsync();
		}
	}
}
