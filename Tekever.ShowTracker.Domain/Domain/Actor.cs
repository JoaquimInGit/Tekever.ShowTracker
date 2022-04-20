using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekever.ShowTracker.Domain.Domain
{
	public class Actor
	{
		public Guid Id { get; set; }
		public int ActorId { get; set; }
		public string Name { get; set; }

		public Actor(int actorId, string name)
		{
			Id = Guid.NewGuid();
			ActorId = actorId;
			Name = name;
		}

	}
}
