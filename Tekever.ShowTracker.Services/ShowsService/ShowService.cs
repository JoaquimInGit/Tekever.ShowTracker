using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Domain.Domain;
using Tekever.ShowTracker.Domain.Interfaces;
using Tekever.ShowTracker.Services.Dtos;
using Tekever.ShowTracker.Services.Interfaces;

namespace Tekever.ShowTracker.Services
{
    public class ShowService : IShowService
    {
        private readonly HttpClient _client = new();
        private List<Show> _shows = new List<Show>();

        private readonly IShowRepository _showRepo;

        private readonly IActorRepository _actorRepository;

        private readonly IGenreRepository _genreRepository;

        private readonly IConfiguration _config;
       // private string apiKey = "2f60c57dcec4758a3969523b7e2791a8";

        public ShowService(IShowRepository showRepo, IActorRepository actorRepo, IGenreRepository genreRepository, IConfiguration config)
		{
            _showRepo = showRepo;
            _actorRepository = actorRepo;  
            _genreRepository = genreRepository;
            _config = config;
		}

        public async IAsyncEnumerable<Show> GetShows(string name)
        {
            _client.DefaultRequestHeaders.Accept.Clear();

            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage? jsonTask = await _client.GetAsync($"https://api.themoviedb.org/3/search/tv?api_key={_config["tmdbKey"]}&query={name}");

            jsonTask.EnsureSuccessStatusCode();

            string? res = await jsonTask.Content.ReadAsStringAsync();

            JObject json = JObject.Parse(res);

            var showsIds = json["results"]?.AsEnumerable().Select(
                result =>
                    result["id"].Value<ulong>()
                    );

           foreach(ulong id in showsIds)
			{               
                yield return await GetShowDetails(id);
            }
        }

        public async Task<Show> GetShowDetails(ulong showId)
        {
            _client.DefaultRequestHeaders.Accept.Clear();

            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


            var url = $"https://api.themoviedb.org/3/tv/{showId}?api_key={_config["tmdbKey"]}&language=en-US&append_to_response=credits";
        
            HttpResponseMessage? jsonTask = await _client.GetAsync(url);

            jsonTask.EnsureSuccessStatusCode();

            string? res = await jsonTask.Content.ReadAsStringAsync();

            Root dto = JsonConvert.DeserializeObject<Root>(res);

            var show = ShowMapper.ShowDtoToShow(dto);
            var cast = ShowMapper.ShowDtoToActorList(dto);
            var genres = ShowMapper.ShowDtoToGenre(dto);
            show.Actors = cast.ConvertAll(actor => actor.ActorId);
            show.Genres = genres.ConvertAll(genre => genre.GenreId);
            show.Episodes = await GetEpisodes(show.ShowId, dto.number_of_seasons);
            await Persist(show, cast, genres);

            return show;

        }

        private async Task Persist(Show show, List<Actor> cast, List<GenreType> genres)
		{
            await _showRepo.AddIfDoesntExist(show);

			if (cast.Count != 0)
			{
                foreach (var actor in cast)
                {
                    await _actorRepository.AddIfDoesntExist(actor);
                }
                
			}
            foreach(var genre in genres)
			{
                await _genreRepository.AddIfDoesntExist(genre);
            }
        }

        public async Task<List<Episode>> GetEpisodes(int showId, int nSeasons)
		{
            var episodeList = new List<Episode>();
            try
            {
               

                _client.DefaultRequestHeaders.Accept.Clear();

                _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                for (int i = 1; i <= nSeasons; i++)
                {
                    var url = $"https://api.themoviedb.org/3/tv/{showId}/season/{i}?api_key={_config["tmdbKey"]}&language=en-US";
                    HttpResponseMessage? jsonTask = await _client.GetAsync(url);
                    jsonTask.EnsureSuccessStatusCode();

                    string? res = await jsonTask.Content.ReadAsStringAsync();

                    EpisodeDto.Root dto = JsonConvert.DeserializeObject<EpisodeDto.Root>(res);

                    var epList = ShowMapper.EpisodeDtoToEpisodeList(dto);

                    episodeList.AddRange(epList);
                }
                return episodeList;
            }
            catch (Exception ex) { }
            return episodeList;
        }
    }
}
