using BeeExplorers.Application.VisualModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekever.ShowTracker.Application.VisualModels.ActorVisualModels
{
	public class ActorVm : ResponseVm
	{
		public int ActorId { get; set; }	
		public string Name { get; set; }

		public ActorVm(int actorId, string name)
		{
			ActorId = actorId;	
			Name = name;
		}

		public ActorVm()
		{

		}
	}
}
