using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekever.ShowTracker.Services.Dtos
{
	public class AppToken
	{
        public string Id { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; }

        public DateTime ValidTo { get; set; }

        public AppToken(string id, string email, string name, string surname, string picture, DateTime validTo)
        {
            Id = id;
            Email = email;
            Name = name;
            Surname = surname;
            Picture = picture;
            ValidTo = validTo;
        }
    }
}
