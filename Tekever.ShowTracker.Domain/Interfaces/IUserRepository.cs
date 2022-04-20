using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Domain.Domain;

namespace Tekever.ShowTracker.Domain.Interfaces
{
	public interface IUserRepository
	{
		public Task<User> GetByEmail(string email);
		public Task<User> GetById(Guid userId);
		public Task<User> AddUser(User user);
		public Task<bool> AddFavoriteShow(int showId, Guid userId);
		public Task<bool> RemoveFavoriteShow(int showId, Guid userId);
		public Task<List<Show>> GetFavoriteShowsList(Guid userId);
	}
}
