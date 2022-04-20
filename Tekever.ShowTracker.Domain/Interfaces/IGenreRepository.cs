using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Domain.Domain;

namespace Tekever.ShowTracker.Domain.Interfaces
{
	public interface IGenreRepository
	{
		public Task<GenreType> GetGenreById(int genreId);
		public Task PersistGenres(List<GenreType> genresList);
		public Task<List<GenreType>> SearchGenres(string Genrename);
		public Task<List<GenreType>> GetAllGenres();
		public Task AddIfDoesntExist(GenreType genre);
		public Task<List<GenreType>> GetGenresByIdList(List<int> genresList);
	}
}
