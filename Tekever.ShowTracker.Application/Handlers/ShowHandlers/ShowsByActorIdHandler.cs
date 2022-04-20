using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Application.ActionModels.Queries;
using Tekever.ShowTracker.Application.VisualModels.ShowVisualModels;
using Tekever.ShowTracker.Domain;
using Tekever.ShowTracker.Domain.Interfaces;

namespace Tekever.ShowTracker.Application.Handlers.ShowHandlers
{
	public class ShowsByActorIdHandler : IRequestHandler<ShowsByActorIdQuery, ShowsVm>
	{
		private readonly IShowRepository _showRepository;
		public ShowsByActorIdHandler(IShowRepository showRepo)
		{
			_showRepository = showRepo;
		}
		public async Task<ShowsVm> Handle(ShowsByActorIdQuery request, CancellationToken cancellationToken)
		{
			var showsVmList = new List<ShowVm>();
			var showList = await _showRepository.GetShowsByActorId(request.ActorId);
			if (showList == null || showList.Count == 0)
			{
				throw new CustomException(7, "No movies found for that actor");
			}
			foreach (var show in showList)
			{
				showsVmList.Add(new ShowVm(show));
			}
			return new ShowsVm(showsVmList);
		}
	}
}
