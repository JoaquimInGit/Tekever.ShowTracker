using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Application.VisualModels.GenreVisualModels;

namespace Tekever.ShowTracker.Application.ActionModels.Queries.GenreQueries
{
	public class GetGenreByIdQuery : IRequest<GenreVm>
	{
		public int GenreId { get; set; }
		public GetGenreByIdQuery(int genreId)
		{
			GenreId = genreId;
		}
	}
}
