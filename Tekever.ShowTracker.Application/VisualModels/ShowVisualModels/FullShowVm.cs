using BeeExplorers.Application.VisualModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Application.VisualModels.ActorVisualModels;
using Tekever.ShowTracker.Application.VisualModels.GenreVisualModels;
using Tekever.ShowTracker.Domain.Domain;

namespace Tekever.ShowTracker.Application.VisualModels.ShowVisualModels
{
	public class FullShowVm : ResponseVm
	{
		public FullShowVm(int showId, string title, string description, List<Episode> episodes, List<ActorVm> actors, List<GenreVm> genres)
		{
			ShowId = showId;
			Title = title;
			Description = description;

			episodes.ForEach(episode =>
			Episodes.Add(new EpisodeVm(episode.Name, episode.AirDate, episode.Season, episode.EpisodeNumber)));

			Cast = actors;
			Genres = genres;
		}

		public Guid Id { get; set; }
		public int ShowId { get; set; }
		public string Title { get; set; }
		public string Description { get; set; }

		public List<EpisodeVm>? Episodes { get; set; } = new List<EpisodeVm>();
		public List<ActorVm>? Cast { get; set; } = null;
		public List<GenreVm>? Genres { get; set; } = null;

		public FullShowVm()
		{

		}
	}
}
