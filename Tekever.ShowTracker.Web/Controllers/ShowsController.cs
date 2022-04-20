using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Tekever.ShowTracker.Application.ActionModels.Queries;
using Tekever.ShowTracker.Application.ActionModels.Queries.ShowQueries;
using Tekever.ShowTracker.Application.VisualModels.ShowVisualModels;
using Tekever.ShowTracker.Domain;

namespace Tekever.ShowTracker.Web.Controllers
{
	[ApiController]

	public class ShowsController : Controller
	{
		private readonly IMediator _mediator;
		public ShowsController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route("shows/search/name")]
		public async Task<ShowsVm> GetShowsByName([FromQuery][Required] string name)
		{
			ShowsVm response = new();
			try
			{
				response = response = await _mediator.Send(new ShowsQuery(name));
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
		[Route("shows")]
		public async Task<ShowsVm> GetAllShows()
		{
			ShowsVm response = new();
			try
			{
				response = await _mediator.Send(new AllShowsQuery());
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
		[Route("shows/id")]
		public async Task<FullShowVm> GetShowById([FromQuery][Required] int showId)
		{
			FullShowVm response = new();

			try
			{
				response = await _mediator.Send(new ShowByIdQuery(showId));
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
		[Route("shows/genre/id")]
		public async Task<ShowsVm> GetShowByGenreId([FromQuery][Required] int genreId)
		{
			ShowsVm response = new();

			try
			{
				response = await _mediator.Send(new ShowByGenreIdQuery(genreId));
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
		[Route("shows/actor")]
		public async Task<ShowsVm> GetShowByActorId([FromQuery][Required] int actorId)
		{
			ShowsVm response = new();

			try
			{
				response = await _mediator.Send(new ShowsByActorIdQuery(actorId));
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
