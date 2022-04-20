using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Application.VisualModels.ShowVisualModels;

namespace Tekever.ShowTracker.Application.ActionModels.Queries.ShowQueries
{
	public class ShowByGenreIdQuery : IRequest<ShowsVm>
	{
		public int GenreId { get; set; }
		public ShowByGenreIdQuery(int genreId)
		{
			GenreId = genreId;
		}
	}
}
