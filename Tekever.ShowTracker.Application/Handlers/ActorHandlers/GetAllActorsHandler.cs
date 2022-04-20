using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Application.ActionModels.Queries.ActorQueries;
using Tekever.ShowTracker.Application.VisualModels.ActorVisualModels;
using Tekever.ShowTracker.Domain;
using Tekever.ShowTracker.Domain.Interfaces;

namespace Tekever.ShowTracker.Application.Handlers.ActorHandlers
{
	public class GetAllActorsHandler : IRequestHandler<GetAllActorsQuery, ActorsVm>
	{
		private readonly IActorRepository _actorRepository;

		public GetAllActorsHandler(IActorRepository actorRepo)
		{
			_actorRepository = actorRepo;
		}
		public async Task<ActorsVm> Handle(GetAllActorsQuery request, CancellationToken cancellationToken)
		{
			var ListActorsVm = new List<ActorVm>();
			var listActors = await _actorRepository.GetAllActors();
			if (listActors == null || listActors.Count == 0)
			{
				throw new CustomException(3, "There are no actors, Search some movies first");
			}
			foreach (var actor in listActors)
			{
				ListActorsVm.Add(new ActorVm(actor.ActorId, actor.Name));
			}
			return new ActorsVm(ListActorsVm);
		}
	}
}
