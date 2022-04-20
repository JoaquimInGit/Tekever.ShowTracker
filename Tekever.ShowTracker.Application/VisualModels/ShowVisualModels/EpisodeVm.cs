using BeeExplorers.Application.VisualModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekever.ShowTracker.Application.VisualModels.ShowVisualModels
{
	public class EpisodeVm
	{
		public string Name { get; set; }
		public DateTime? AirDate { get; set; } = null;
		public int Season { get; set; }
		public int EpisodeNumber { get; set; }

		public EpisodeVm(string name, DateTime? airDate, int season, int epNum)
		{
			Name = name;
			AirDate = airDate;
			Season = season;
			EpisodeNumber = epNum;
		}
	}
}
