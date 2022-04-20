using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Tekever.ShowTracker.Application.ActionModels.Queries.ActorQueries;
using Tekever.ShowTracker.Application.VisualModels.ActorVisualModels;
using Tekever.ShowTracker.Domain;

namespace Tekever.ShowTracker.Web.Controllers
{
	[ApiController]
	public class ActorsController : Controller
	{
		private readonly IMediator _mediator;
		public ActorsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route("actor/search/id")]
		public async Task<ActorVm> GetActorById([FromQuery][Required] int actorId)
		{
			ActorVm response = new();
			try
			{
				response = await _mediator.Send(new GetActorByIdQuery(actorId));
				return response;
			}
			catch (CustomException ex)
			{
				response.ErrorCode = ex.ErrorCode;
				response.Message = ex.Message;
				return response;
			}
			
		}

		[HttpGet]
		[Route("actor")]
		public async Task<ActorsVm> GetAllActors()
		{
			ActorsVm response = new();
			try
			{
				response = await _mediator.Send(new GetAllActorsQuery());
				return response;
			}
			catch (CustomException ex)
			{
				response.ErrorCode = ex.ErrorCode;
				response.Message = ex.Message;
				return response;
			}

		}

	}
}
