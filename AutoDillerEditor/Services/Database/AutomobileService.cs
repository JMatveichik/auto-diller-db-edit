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
	internal class AutomobileService : DatabaseServiceBase, IAutomobileService
	{

		public AutomobileService(AppDatabaseContext context) : base(context)
		{

		}

		public async Task<IEnumerable<Automobile>> GetAllAutomobilesAsync()
		{
			return await _context.Automobiles.ToListAsync();
		}
	}
}
