using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekever.ShowTracker.Domain.Domain
{
	public class Favorite
	{
		public Guid Id { get; set; }
		public int ShowId { get; set; }
		public Guid UserId { get; set; }
		public virtual User User { get; set; }

		public Favorite(int showId, Guid userId)
		{
			Id = Guid.NewGuid();
			ShowId = showId;
			UserId = userId;
		}

		public Favorite()
		{

		}
	}
}
