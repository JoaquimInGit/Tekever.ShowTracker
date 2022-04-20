using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Application.ActionModels.Queries;
using Tekever.ShowTracker.Application.VisualModels.ActorVisualModels;
using Tekever.ShowTracker.Application.VisualModels.GenreVisualModels;
using Tekever.ShowTracker.Application.VisualModels.ShowVisualModels;
using Tekever.ShowTracker.Domain;
using Tekever.ShowTracker.Domain.Interfaces;

namespace Tekever.ShowTracker.Application.Handlers
{
	public class ShowByIdHandler : IRequestHandler<ShowByIdQuery, FullShowVm>
	{
		private readonly IShowRepository _showRepository;
		private readonly IActorRepository _actorRepository;
		private readonly IGenreRepository _genreRepository;
		public ShowByIdHandler(IShowRepository showRepo, IActorRepository actorRepository, IGenreRepository genreRepository)
		{
			_showRepository = showRepo;
			_actorRepository = actorRepository;
			_genreRepository = genreRepository;
		}
		public async Task<FullShowVm> Handle(ShowByIdQuery request, CancellationToken cancellationToken)
		{
			var cast = new List<ActorVm>();
			var genresVmList = new List<GenreVm>();
			var show = await _showRepository.GetShowById(request.ShowId);
			if (show == null)
			{
				throw new CustomException(6, "There is no show with that Id");
			}
			var actorList = await _actorRepository.GetActorsFromIdList(show.Actors);
			var genresList = await _genreRepository.GetGenresByIdList(show.Genres);
			if (actorList.Count != 0)
			{
				foreach (var actor in actorList)
				{
					cast.Add(new ActorVm(actor.ActorId, actor.Name));
				};
			}

			if (actorList.Count != 0)
			{
				foreach (var genre in genresList)
				{
					genresVmList.Add(new GenreVm(genre.GenreId, genre.Name));
				}
			}

			return new FullShowVm(show.ShowId, show.Title, show.Description, show.Episodes, cast, genresVmList);
		}
	}
}
