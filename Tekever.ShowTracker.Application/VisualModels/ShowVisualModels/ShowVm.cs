using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Domain.Domain;

namespace Tekever.ShowTracker.Application.VisualModels.ShowVisualModels
{
	public class ShowVm
	{
		public int Id { get; set; }
		public string Title { get; set; }

		public ShowVm(Show show)
		{
			Id = show.ShowId;
			Title = show.Title;
		}
	}
}
