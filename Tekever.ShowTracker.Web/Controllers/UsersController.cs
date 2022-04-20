using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tekever.ShowTracker.Application.ActionModels.Commands;
using Tekever.ShowTracker.Application.VisualModels.ShowVisualModels;
using Tekever.ShowTracker.Services.Interfaces;

namespace Tekever.ShowTracker.Web.Controllers
{
	[ApiController]
	public class UsersController : Controller
	{
		private readonly IMediator _mediator;
		private readonly ITokenService _tokenService;
		private readonly IConfiguration _config;
		public UsersController(IMediator mediator, ITokenService tokenService, IConfiguration config)
		{
			_mediator = mediator;
			_tokenService = tokenService;
			_config = config;
		}
		[Authorize(policy:"Access")]
		[HttpPost]
		[Route("user/favorite/create")]
		public async Task<FullShowVm> AddFavoriteShow([FromQuery] int showId)
		{
			var jwt = Request.Headers.Authorization;
			var appToken = _tokenService.ReadAppToken(jwt);
			var response = await _mediator.Send(new AddFavoriteShowCommand(showId, Guid.Parse(appToken.Id)));

			return response;
		}

		[Authorize(policy: "Access")]
		[HttpDelete]
		[Route("user/favorite/delete")]
		public async Task<FavoriteListVm> RemoveFavoriteShow([FromQuery] int showId)
		{
			var jwt = Request.Headers.Authorization;
			var appToken = _tokenService.ReadAppToken(jwt);
			var response = await _mediator.Send(new RemoveFavoriteShowCommand(showId, Guid.Parse(appToken.Id)));

			return response;
		}

	}
}
