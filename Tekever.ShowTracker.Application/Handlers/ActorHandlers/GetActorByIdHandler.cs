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
	public class GetActorByIdHandler : IRequestHandler<GetActorByIdQuery, ActorVm>
	{
		private readonly IActorRepository _actorRepository;

		public GetActorByIdHandler(IActorRepository actorRepo)
		{
			_actorRepository = actorRepo;
		}
		public async Task<ActorVm> Handle(GetActorByIdQuery request, CancellationToken cancellationToken)
		{
	
			var actor = await _actorRepository.GetActorById(request.ActorId);
			if (actor == null)
			{
				throw new CustomException(2, "Actor not found");
			}
			
			return new ActorVm(actor.ActorId, actor.Name);
		}
	}
}
