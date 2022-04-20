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
	public class GenreRepository : IGenreRepository
	{
		private readonly IMongoCollection<GenreType> _genre;
		public GenreRepository(IMongoCollection<GenreType> genre)
		{
			_genre = genre;
		}
		public async Task AddIfDoesntExist(GenreType genre)
		{
			var document = await _genre.Find(shw => shw.GenreId == genre.GenreId).CountDocumentsAsync();
			if (document == 0)
			{
				await _genre.InsertOneAsync(genre);
			}
		}

		public async Task<List<GenreType>> GetAllGenres()
		{
			var result = await _genre.Find(_ => true).ToListAsync();
			return result;
		}

		public async Task<GenreType> GetGenreById(int genreId)
		{
			var genre = await _genre.Find(genre => genre.GenreId == genreId).FirstOrDefaultAsync();
			return genre;
		}

		public async Task<List<GenreType>> GetGenresByIdList(List<int> genresList)
		{
			var list = await _genre.Find(genre => genresList.Contains(genre.GenreId)).ToListAsync();
			return list;
		}

		public async Task PersistGenres(List<GenreType> genresList)
		{
			await _genre.InsertManyAsync(genresList);
		}

		public Task<List<GenreType>> SearchGenres(string Genrename)
		{
			throw new NotImplementedException();
		}
	}
}
