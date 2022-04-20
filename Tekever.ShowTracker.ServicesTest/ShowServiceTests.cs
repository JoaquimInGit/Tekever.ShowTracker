using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Domain.Domain;
using Tekever.ShowTracker.Domain.Interfaces;
using Tekever.ShowTracker.Repository.Repositories;
using Tekever.ShowTracker.Services;
using Tekever.ShowTracker.Services.Interfaces;
using Xunit;

namespace Tekever.ShowTracker.ServicesTest
{
	public class ShowServiceTests : IClassFixture<ShowService>
	{
		
		private readonly IShowService _service;

		public ShowServiceTests(IShowService service)
		{
			_service = service;
		}
		[Fact]
		public async Task ServiceShouldGetShowsByNameAsync()
		{

			//await _service.GetShows("dexter");

			//var showList = shows.ToList<Show>();

			//showList.ShouldNotBeEmpty();
		}
	}
}
