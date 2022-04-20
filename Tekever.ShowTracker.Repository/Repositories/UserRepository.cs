using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Domain.Domain;
using Tekever.ShowTracker.Domain.Interfaces;
using Tekever.ShowTracker.Repository.Contexts;

namespace Tekever.ShowTracker.Repository.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ShowTrackerContext _context;

		public UserRepository(ShowTrackerContext context)
		{
			_context = context;
		}

		public async Task<bool> AddFavoriteShow(int showId, Guid userId)
		{
			_context.Favorites.Add(new Favorite(showId, userId));
			var result = await _context.SaveChangesAsync();
			return true;
		}

		public async Task<User> AddUser(User user)
		{
			_context.Users.Add(user);
			await _context.SaveChangesAsync();
			return user;
		}

		public async Task<User> GetByEmail(string email)
		{
			var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);
			return user;
		}

		public Task<User> GetById(Guid userId)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> RemoveFavoriteShow(int showId, Guid userId)
		{
			var favorite = await _context.Favorites.FirstOrDefaultAsync(fav => fav.ShowId == showId && fav.UserId == userId);
			_context.Favorites.Remove(favorite);	
			var code = await _context.SaveChangesAsync();
			return code == 0;	
		}

		public Task<List<Show>> GetFavoriteShowsList(Guid userId)
		{
			throw new NotImplementedException();
		}
	}
}
