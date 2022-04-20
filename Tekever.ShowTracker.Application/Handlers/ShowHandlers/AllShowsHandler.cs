using BeeExplorers.Application.VisualModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Application.ActionModels.Queries;
using Tekever.ShowTracker.Application.VisualModels.ShowVisualModels;
using Tekever.ShowTracker.Domain;
using Tekever.ShowTracker.Domain.Domain;
using Tekever.ShowTracker.Domain.Interfaces;

namespace Tekever.ShowTracker.Application.Handlers
{
	public class AllShowsHandler : IRequestHandler<AllShowsQuery, ShowsVm>
	{
		private readonly IShowRepository _showRepository;

		public AllShowsHandler(IShowRepository shows)
		{
			_showRepository = shows;
		}

		public async Task<ShowsVm> Handle(AllShowsQuery request, CancellationToken cancellationToken)
		{
			var showList = new List<Show>();
			showList = await _showRepository.GetAllShows();
			if (showList.Count() == 0 || showList == null)
			{
				throw new CustomException(4, "There are not movies Yet, Search some first :)");
			}

			var showsVmList = new List<ShowVm>();

			foreach (var show in showList)
			{
				showsVmList.Add(new ShowVm(show));
			}
			return new ShowsVm(showsVmList);
		}
	}
}
