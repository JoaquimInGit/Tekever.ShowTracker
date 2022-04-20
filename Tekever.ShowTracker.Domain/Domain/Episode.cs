using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekever.ShowTracker.Domain.Domain
{
	public class Episode
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public DateTime? AirDate { get; set; } = null;
		public int Season { get; set; }
		public int EpisodeNumber { get; set; }
		public Episode(string name, string? date, int season, int epNum)
		{
			Name = name;
			if(date != null && date != "")
			{
				AirDate = DateTime.Parse(date);
			}
			Season = season;
			EpisodeNumber = epNum;
		}
	}
}
