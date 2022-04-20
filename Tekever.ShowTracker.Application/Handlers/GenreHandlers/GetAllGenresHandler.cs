using BeeExplorers.Application.VisualModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Application.ActionModels.Queries.GenreQueries;
using Tekever.ShowTracker.Application.VisualModels.GenreVisualModels;
using Tekever.ShowTracker.Domain;
using Tekever.ShowTracker.Domain.Interfaces;

namespace Tekever.ShowTracker.Application.Handlers.GenreHandlers
{
	public class GetAllGenresHandler : IRequestHandler<GetAllGenresQuery, GenresVm>
	{
		private readonly IGenreRepository _genreRepository;
		public GetAllGenresHandler(IGenreRepository genreRepo)
		{
			_genreRepository = genreRepo;
		}
		public async Task<GenresVm> Handle(GetAllGenresQuery request, CancellationToken cancellationToken)
		{
			var genreListVm = new List<GenreVm>();
			var genresList = await _genreRepository.GetAllGenres();
			if(genresList == null || genresList.Count == 0)
			{
				throw new CustomException(1,"There Are no Genres yet, search some movies first");
			}
			foreach (var genre in genresList)
			{
				genreListVm.Add(new GenreVm(genre.GenreId, genre.Name));
			}

			return new GenresVm(genreListVm);
			
		}
	}
}
