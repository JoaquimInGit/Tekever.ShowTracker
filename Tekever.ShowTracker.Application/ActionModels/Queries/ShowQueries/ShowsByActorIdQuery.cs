using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Application.VisualModels.ShowVisualModels;

namespace Tekever.ShowTracker.Application.ActionModels.Queries
{
	public class ShowsByActorIdQuery : IRequest<ShowsVm>
	{
		public int ActorId { get; set; }

		public ShowsByActorIdQuery(int actorId)
		{
			ActorId = actorId;
		}
	}
}
