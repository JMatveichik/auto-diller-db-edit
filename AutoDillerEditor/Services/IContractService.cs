using AutoLandProcessor.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLandProcessor.Services
{
    internal interface IContractService
    {
		Task<IEnumerable<Contract>> GetAllContractsAsync();
	}
}
