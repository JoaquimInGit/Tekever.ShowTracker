using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekever.ShowTracker.Services.Interfaces
{
	public interface IGoogleAuthenticationService
	{
		public Task<string> Authentication();

		public Task<string> GetIdToken(string authCode);
	}
}
