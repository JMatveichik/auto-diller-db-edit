using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoLandProcessor.Services
{
	internal interface INavigationService
	{
		void ShowLoginDialog();
		void ShowMainView();
		void CloseLoginDialog();
	}
}
