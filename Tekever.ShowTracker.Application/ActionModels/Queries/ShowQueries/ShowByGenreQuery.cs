using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Application.VisualModels.ShowVisualModels;

namespace Tekever.ShowTracker.Application.ActionModels.Queries
{
	public class ShowByGenreQuery : IRequest<ShowsVm>
	{
		public int? GenreId { get; set; }
		public string? GenreName { get; set; }

		public ShowByGenreQuery(int? genreId, string? genreName)
		{
			GenreId = genreId;
			GenreName = genreName;
		}
	}
}
