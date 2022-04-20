using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Domain.Domain;

namespace Tekever.ShowTracker.Domain.Interfaces
{
	public interface IActorRepository
	{
		public Task<bool> PersistActors(List<Actor> cast);
		public Task<List<Actor>> GetAllActors();
		public Task<Actor> GetActorById(int id);
		public Task<List<Actor>> GetActorsByName(string name);
		public Task<bool> DeleteActor(Guid id);
		public Task<bool> UpdateActor(Guid id);
		public Task AddIfDoesntExist(Actor actor);

		public Task<List<Actor>> GetActorsFromIdList(List<int> actors);
	}
}
