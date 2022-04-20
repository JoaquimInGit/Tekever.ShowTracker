using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Domain.Domain;

namespace Tekever.ShowTracker.Services.Interfaces
{
	public interface IShowService
	{
		public  Task<Show> GetShowDetails(ulong showId);
		public IAsyncEnumerable<Show> GetShows(string name);
		public Task<List<Episode>> GetEpisodes(int showId, int nSeasons);
	}
}
