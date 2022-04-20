using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Repository.Repositories;
using Xunit;

namespace Tekever.ShowTracker.PersistenceTests
{
	public class ShowRepositoryTests
	{


		ObjectDatabaseTestConnection connection;


		ShowRepository showRepo;

		public ShowRepositoryTests()
		{
			connection = new ObjectDatabaseTestConnection();
			showRepo = new ShowRepository(connection.showCollection);
		}

			[Fact]
			public async void ShouldSearchByName()
			{
				var result = await showRepo.GetShowsByName("dexter:");
				result.Count().ShouldBe(2);
			}


		[Fact]
		public async void ShouldGetAll()
		{
			var result = await showRepo.GetAllShows();
			result.ShouldNotBeEmpty() ;
		}

	}
}
