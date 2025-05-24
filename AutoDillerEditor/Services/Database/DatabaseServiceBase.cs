using AutoLandProcessor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLandProcessor.Services
{
    internal class DatabaseServiceBase
    {
		protected readonly AppDatabaseContext _context;

		public DatabaseServiceBase(AppDatabaseContext context)
		{
			_context = context;
		}
	}
}
