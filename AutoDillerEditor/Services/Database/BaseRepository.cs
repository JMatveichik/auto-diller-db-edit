using AutoLandProcessor.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLandProcessor.Services
{
    internal class BaseRepository
    {
		protected readonly AppDBContext _context;

		public BaseRepository(AppDBContext context)
		{
			_context = context;
		}
	}
}
