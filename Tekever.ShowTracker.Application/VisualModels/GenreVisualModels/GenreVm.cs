using BeeExplorers.Application.VisualModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekever.ShowTracker.Application.VisualModels.GenreVisualModels
{
	public class GenreVm : ResponseVm
	{
		public int GenreId { get; set; }
		public string Name { get; set; }

		public GenreVm(int genreId, string name)
		{
			GenreId = genreId;
			Name = name;
		}
		public GenreVm()
		{

		}
	}
}
