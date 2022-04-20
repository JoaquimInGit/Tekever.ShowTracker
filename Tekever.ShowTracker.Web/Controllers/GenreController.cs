using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using Tekever.ShowTracker.Application.ActionModels.Queries.GenreQueries;
using Tekever.ShowTracker.Application.VisualModels.GenreVisualModels;
using Tekever.ShowTracker.Domain;

namespace Tekever.ShowTracker.Web.Controllers
{
	public class GenreController : Controller
	{
		private readonly IMediator _mediator;
		public GenreController(IMediator mediator)
		{
			_mediator = mediator;
		}

		[HttpGet]
		[Route("genre/search/id")]
		public async Task<GenreVm> GetGenreById([FromQuery][Required] int genreId)
		{
			GenreVm response = new();
			try
			{
				response = await _mediator.Send(new GetGenreByIdQuery(genreId));
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
		[Route("genre")]
		public async Task<GenresVm> GetAllGenres()
		{
			GenresVm response = new();
			try
			{
				response = await _mediator.Send(new GetAllGenresQuery());
				return response;
			}
			catch (CustomException ex)
			{
				response.ErrorCode = ex.ErrorCode;
				response.Message = ex.Message;
				return response;
			}
			
			//return response;
		}
	}
}
