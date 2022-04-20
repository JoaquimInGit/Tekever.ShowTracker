using BeeExplorers.Application.VisualModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Domain.Domain;

namespace Tekever.ShowTracker.Application.VisualModels.ShowVisualModels
{
	public class ShowsVm : ResponseVm
	{
		public IEnumerable<ShowVm> Shows { get; set; }
		public ShowsVm(IEnumerable<ShowVm> shows)
		{
			Shows = shows;
		}

		public ShowsVm()
		{

		}
	}
}
