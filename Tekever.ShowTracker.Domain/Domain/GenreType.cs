using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekever.ShowTracker.Domain.Domain
{
	public class GenreType
	{
		public Guid Id { get; set; }
		public int GenreId { get; set; }
		public string Name { get; set; }

		public GenreType(int genreId, string name)
		{
			Id = Guid.NewGuid();
			GenreId = genreId;
			Name = name;
		}
	}
}
