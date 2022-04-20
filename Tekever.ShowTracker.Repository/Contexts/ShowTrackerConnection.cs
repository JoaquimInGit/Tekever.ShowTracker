using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekever.ShowTracker.Repository.Contexts
{
	public class ShowTrackerConnection
	{
		public string ConnectionString { get; set; } = null!;

		public string DatabaseName { get; set; } = null!;

		public string ShowCollectionName { get; set; } = null!;
		public string ActorCollectionName { get; set; } = null!;
		public string GenreTypeCollectionName { get; set; } = null!;
	}
}
