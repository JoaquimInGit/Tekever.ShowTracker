using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Application.VisualModels.ShowVisualModels;

namespace Tekever.ShowTracker.Application.ActionModels.Queries
{
	public class ShowByIdQuery : IRequest<FullShowVm>
	{
		public int ShowId { get; set; }

		public ShowByIdQuery(int showid)
		{
			ShowId = showid;
		}
	}
}
