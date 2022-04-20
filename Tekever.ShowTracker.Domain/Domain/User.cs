using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekever.ShowTracker.Domain.Domain
{
	public class User
	{
		public Guid Id { get; set; }
		public string Name { get; set; }
		public string Email { get; set; }
		public virtual ICollection<Favorite>? Favorites { get; set; }

		public User(Guid id, string name, string email)
		{
			Id = id;
			Name = name;
			Email = email;
		}
	}
}
