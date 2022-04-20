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
	public class GetGenreByIdHandler : IRequestHandler<GetGenreByIdQuery, GenreVm>
	{
		private readonly IGenreRepository _genreRepository;
		public GetGenreByIdHandler(IGenreRepository genreRepo)
		{
			_genreRepository = genreRepo;
		}
		public async Task<GenreVm> Handle(GetGenreByIdQuery request, CancellationToken cancellationToken)
		{
			var genre = await _genreRepository.GetGenreById(request.GenreId);
			if (genre == null)
			{
				throw new CustomException(2, "Genre Not Found");
			}
			return new GenreVm(genre.GenreId,genre.Name);
		}
	}
}
