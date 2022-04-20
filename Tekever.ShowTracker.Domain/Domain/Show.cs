using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekever.ShowTracker.Domain.Domain
{
	public class Show
	{
		public Show(int showId, 
			string title, 
			string description, 
			string? startDate, 
			string? endDate,
			List<string>? countries
			)
		{
			Id = Guid.NewGuid();
			ShowId = showId;
			Title = title;
			Description = description;
			if (startDate != null)
			{
				StartDate = DateTime.Parse(endDate);
			}

			if (endDate != null)
			{
				EndDate = DateTime.Parse(endDate);
			}

			Countries = countries;
		}

		public Guid Id { get; set; }
		public int ShowId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }
		public List<Episode>? Episodes { get; set; }
		public DateTime? StartDate { get; set; } = null;
		public DateTime? EndDate { get; set; } = null;
		public List<int>? Actors { get; set; }
		public List<int>? Genres { get; set; }
		public List<string>? Countries { get; set; }
	}

}
