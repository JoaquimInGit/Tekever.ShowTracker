using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Domain.Domain;

namespace Tekever.ShowTracker.Domain.Interfaces
{
	public interface IShowRepository
	{
		public Task<bool> PersistShows(List<Show> shows);
		public Task<List<Show>> GetAllShows();
		public Task<Show> GetShowById(int id);
		public Task<List<Show>> GetShowsByName(string name);
		public Task<bool> DeleteShow(Guid id);
		public Task<bool> UpdateShow(Guid id);
		public Task<bool> AddIfDoesntExist(Show shows);
		public Task<List<Show>> GetShowsByActorId(int actorId);
		public Task<List<Show>> GetShowsByGenreName(string name);
		public Task<List<Show>> GetShowsByGenreId(int genreId);

	}
}
