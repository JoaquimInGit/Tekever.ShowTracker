using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Domain.Domain;

namespace Tekever.ShowTracker.Services.Dtos
{
	public class ShowMapper
	{
		public static Show ShowDtoToShow(Root dto)
		{


			return new Show(
						dto.id,
						dto.name,
						dto.overview,
						dto.first_air_date,
						dto.last_air_date,
						dto.origin_country
						);
		
		}

		public static List<Actor> ShowDtoToActorList(Root dto)
		{
			var actors = new List<Actor>();

			dto.credits.cast.ForEach(a =>
				actors.Add(new Actor(a.id, a.name))
			) ;

			return actors;

		}

		public static List<Episode> EpisodeDtoToEpisodeList(EpisodeDto.Root dto)
		{
			var episodeList = new List<Episode>();

			dto.episodes.ForEach(a =>
				episodeList.Add(new Episode(a.name, a.air_date, a.season_number, a.episode_number))
			);

			return episodeList;
		}

		public static List<GenreType> ShowDtoToGenre(Root dto)
		{

			var genreList = new List<GenreType>();

			dto.genres.ForEach(a =>
				genreList.Add(new GenreType(a.id, a.name))
			);

			return genreList;
		}
	}
}
