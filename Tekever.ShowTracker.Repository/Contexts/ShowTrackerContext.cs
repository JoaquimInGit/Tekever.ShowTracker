using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Domain.Domain;
using Microsoft.EntityFrameworkCore;

namespace Tekever.ShowTracker.Repository.Contexts
{
	public class ShowTrackerContext : DbContext
	{
		public DbSet<Favorite> Favorites { get; set; }
		public DbSet<User> Users { get; set; }
		public ShowTrackerContext(DbContextOptions<ShowTrackerContext> ctx) : base(ctx)
		{

		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			base.OnModelCreating(builder);
			builder.Entity<Favorite>().ToTable("Favorites");

			builder.Entity<Favorite>().HasKey("Id");

			builder.Entity<Favorite>()
				.HasOne<User>(x => x.User)
				.WithMany(y => y.Favorites);

			builder.Entity<User>().ToTable("Users");
			builder.Entity<User>().HasKey("Id");

			builder.Entity<User>()
				.HasMany(y => y.Favorites)
				.WithOne(y => y.User);
		}

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			if (!optionsBuilder.IsConfigured)
			{
				var configuration = new ConfigurationBuilder()
					.SetBasePath(Directory.GetCurrentDirectory())
					.AddJsonFile("appsettings.json").Build();

				var connectionString = configuration.GetConnectionString("LocalConnection");

				optionsBuilder.UseNpgsql(connectionString);
			}
		}
	}
}
