using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Tekever.ShowTracker.Domain.Domain;
using Tekever.ShowTracker.Domain.Interfaces;

namespace Tekever.ShowTracker.Repository.Repositories
{
	public class ShowRepository : IShowRepository
	{
		private readonly IMongoCollection<Show> _show;
		public ShowRepository(IMongoCollection<Show> show)
		{
			_show = show;
		}

		public Task<bool> DeleteShow(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Show>> GetAllShows()
		{
			var shows = await _show.Find(Builders<Show>.Filter.Empty).ToListAsync();

			return shows;
		}

		public async Task<bool> AddIfDoesntExist(Show show)
		{

			var document = await _show.Find(shw => shw.ShowId == show.ShowId).CountDocumentsAsync();
			if(document == 0)
			{
				await _show.InsertOneAsync(show);
			}
				
			return true;
		}

		public async Task<Show> GetShowById(int id)
		{
			var document = await _show.Find(shw => shw.ShowId == id).FirstOrDefaultAsync();
			return document;
		}

		public async Task<List<Show>> GetShowsByName(string name)
		{

			var filter = new BsonDocument { { "Title", new BsonDocument { { "$regex", name }, { "$options", "i" } } } };

			var result = await _show.Find(filter).ToListAsync();

			return result;
		}

		public async Task<bool> PersistShows(List<Show> shows)
		{
			await _show.InsertManyAsync(shows);
			return true;
		}

		public Task<bool> UpdateShow(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Show>> GetShowsByActorId(int actorId)
		{
			var filter = _show.Find(x => x.Actors.Contains(actorId));
			return await filter.ToListAsync();
		}

		public async Task<List<Show>> GetShowsByGenreName(string name)
		{
			var filter = new BsonDocument { { "name", new BsonDocument { { "$regex", name }, { "$options", "i" } } } };

			var result = await _show.Find(filter).ToListAsync();

			return result;
		}

		public async Task<List<Show>> GetShowsByGenreId(int genreId)
		{
			

			var result = await _show.Find(show => show.Genres.Contains(genreId))
				.ToListAsync();
			return result;
		}
	}
}
