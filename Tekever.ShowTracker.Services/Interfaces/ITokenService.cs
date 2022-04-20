using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Services.Dtos;

namespace Tekever.ShowTracker.Services.Interfaces
{
	public interface ITokenService
	{
			public string WriteJwtAppToken(AppToken appToken);
			public AppToken ReadGoogleToken(string tokenString);
			public AppToken ReadAppToken(string tokenString);
			public Guid GoogleIdToGuid(string input);
	}
}
