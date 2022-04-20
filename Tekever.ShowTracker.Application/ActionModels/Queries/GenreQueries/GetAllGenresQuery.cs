using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Application.VisualModels.GenreVisualModels;

namespace Tekever.ShowTracker.Application.ActionModels.Queries.GenreQueries
{
	public class GetAllGenresQuery : IRequest<GenresVm>
	{
		public GetAllGenresQuery()
		{

		}
	}
}
