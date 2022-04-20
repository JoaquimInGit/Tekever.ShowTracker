using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Application.ActionModels.Queries;
using Tekever.ShowTracker.Application.VisualModels.ShowVisualModels;
using Tekever.ShowTracker.Domain.Domain;
using Tekever.ShowTracker.Domain.Interfaces;
using Tekever.ShowTracker.Services;
using Tekever.ShowTracker.Services.Interfaces;

namespace Tekever.ShowTracker.Application.Handlers
{
	public class SearchShowHandler : IRequestHandler<ShowsQuery, ShowsVm>
	{
		private readonly IShowRepository _showRepository;
		private readonly IShowService _showService;

		public SearchShowHandler(IShowRepository shows, IShowService service)
		{
			_showRepository = shows;
			_showService = service;
		}
		public async Task<ShowsVm> Handle(ShowsQuery request, CancellationToken cancellationToken)
		{
			var showsVmList = new List<ShowVm>();
			var showList = new List<Show>();
			showList = await _showRepository.GetShowsByName(request.Name);
			if(showList.Count() == 0)
			{
			
				await foreach (var show in _showService.GetShows(request.Name))
				{
					showsVmList.Add(new ShowVm(show));
				}
				return new ShowsVm(showsVmList);

			}

			
			foreach (var show in showList)
			{
				showsVmList.Add(new ShowVm(show));
			}
			return new ShowsVm(showsVmList);
		}
	}
}
