using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Application.VisualModels.ActorVisualModels;

namespace Tekever.ShowTracker.Application.ActionModels.Queries.ActorQueries
{
	public class GetAllActorsQuery : IRequest<ActorsVm>
	{
		public GetAllActorsQuery()
		{

		}
	}
}
