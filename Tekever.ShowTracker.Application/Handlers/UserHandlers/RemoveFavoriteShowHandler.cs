using BeeExplorers.Application.VisualModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Application.ActionModels.Commands;
using Tekever.ShowTracker.Application.VisualModels.ShowVisualModels;
using Tekever.ShowTracker.Domain.Interfaces;

namespace Tekever.ShowTracker.Application.Handlers
{
	public class RemoveFavoriteShowHandler : IRequestHandler<RemoveFavoriteShowCommand, FavoriteListVm>
	{
		private readonly IUserRepository _userRepository;
		public RemoveFavoriteShowHandler(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		public async Task<FavoriteListVm> Handle(RemoveFavoriteShowCommand request, CancellationToken cancellationToken)
		{
			await _userRepository.RemoveFavoriteShow(request.ShowId, request.UserId);

			return new FavoriteListVm();
		}
	}
}
