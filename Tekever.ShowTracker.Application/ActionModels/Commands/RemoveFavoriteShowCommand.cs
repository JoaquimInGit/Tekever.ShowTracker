using BeeExplorers.Application.VisualModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Application.VisualModels.ShowVisualModels;

namespace Tekever.ShowTracker.Application.ActionModels.Commands
{
	public class RemoveFavoriteShowCommand : IRequest<FavoriteListVm>
	{
		public int ShowId { get; set; }
		public Guid UserId { get; set; }

		public RemoveFavoriteShowCommand(int showId, Guid userId)
		{
			ShowId = showId;
			UserId = userId;
		}
	}
}
