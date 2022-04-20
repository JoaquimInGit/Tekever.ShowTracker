using BeeExplorers.Application.VisualModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekever.ShowTracker.Application.VisualModels.GenreVisualModels
{
	public class GenresVm : ResponseVm
	{
		public IEnumerable<GenreVm> Genres { get; set; }
		public GenresVm(IEnumerable<GenreVm> genres)
		{
			Genres = genres;
		}
		public GenresVm()
		{

		}
	}
}
