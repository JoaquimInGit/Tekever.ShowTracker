using BeeExplorers.Application.VisualModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekever.ShowTracker.Application.VisualModels.ActorVisualModels
{
	public class ActorsVm : ResponseVm
	{
		public IEnumerable<ActorVm> Actors { get; set; }
		public ActorsVm(IEnumerable<ActorVm> actors)
		{
			Actors = actors;
		}

		public ActorsVm()
		{

		}
	}
}
