using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Domain.Domain;
using Tekever.ShowTracker.Domain.Interfaces;

namespace Tekever.ShowTracker.Repository.Repositories
{
	public class ActorRepository : IActorRepository
	{
		private readonly IMongoCollection<Actor> _actor;
		public ActorRepository(IMongoCollection<Actor> actor)
		{
			_actor = actor;
		}

		public Task<bool> DeleteActor(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<Actor> GetActorById(int id)
		{
			var document = await _actor.Find(actor => actor.ActorId == id).FirstOrDefaultAsync();
			return document;
		}

		public async Task<List<Actor>> GetActorsByName(string name)
		{
			var filter = new BsonDocument { { "Name", new BsonDocument { { "$regex", name }, { "$options", "i" } } } };

			var result = await _actor.Find(filter).ToListAsync();

			return result;
		}

		public async Task<List<Actor>> GetAllActors()
		{
			var shows = await _actor.Find(Builders<Actor>.Filter.Empty).ToListAsync();

			return shows;
		}

		public async Task<bool> PersistActors(List<Actor> cast)
		{
			await _actor.InsertManyAsync(cast);
			return true;
		}

		public async Task AddIfDoesntExist(Actor actor)
		{
			var document = await _actor.Find(act => act.ActorId == actor.ActorId).CountDocumentsAsync();
			if (document == 0)
			{
				await _actor.InsertOneAsync(actor);
			}
		}

		public Task<bool> UpdateActor(Guid id)
		{
			throw new NotImplementedException();
		}

		public async Task<List<Actor>> GetActorsFromIdList(List<int> actors)
		{
			var actorList = await _actor.Find(actor => actors.Contains(actor.ActorId)).ToListAsync();
			return actorList;
		}
	}

}
