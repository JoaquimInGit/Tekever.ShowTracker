using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Application.ActionModels.Queries;
using Tekever.ShowTracker.Application.ActionModels.Queries.ShowQueries;
using Tekever.ShowTracker.Application.VisualModels.ShowVisualModels;
using Tekever.ShowTracker.Domain;
using Tekever.ShowTracker.Domain.Interfaces;

namespace Tekever.ShowTracker.Application.Handlers
{
	public class ShowByGenreIdHandler : IRequestHandler<ShowByGenreIdQuery, ShowsVm>
	{
		private readonly IShowRepository _showRepository;
		public ShowByGenreIdHandler(IShowRepository showRepository)
		{
			_showRepository = showRepository;
		}
		public async Task<ShowsVm> Handle(ShowByGenreIdQuery request, CancellationToken cancellationToken)
		{
			var showList = await _showRepository.GetShowsByGenreId(request.GenreId);
			var showsVmList = new List<ShowVm>();
			if (showsVmList == null || showsVmList.Count == 0)
			{
				throw new CustomException(5, "there are no movies with that Genre, search some more :)");
			}
			foreach (var show in showList)
			{
				showsVmList.Add(new ShowVm(show));
			}
			return new ShowsVm(showsVmList);
		}
	}
}
