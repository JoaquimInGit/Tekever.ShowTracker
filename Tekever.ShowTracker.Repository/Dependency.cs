using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;
using Tekever.ShowTracker.Domain.Domain;
using Tekever.ShowTracker.Domain.Interfaces;
using Tekever.ShowTracker.Repository.Contexts;
using Tekever.ShowTracker.Repository.Repositories;
namespace Tekever.ShowTracker.Repository
{
	public static class Dependency
	{
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
           IHostEnvironment environment, IConfiguration configuration)
        {
           
            services.AddScoped<IShowRepository, ShowRepository>();
            services.AddScoped<IActorRepository, ActorRepository>();
            services.AddScoped<IUserRepository, UserRepository>();   
            services.AddScoped<IGenreRepository, GenreRepository>();

            services.AddScoped<IMongoCollection<Show>>(_ =>
            {
                var options = configuration.GetSection("TekeverShowsStoreDatabase").Get<ShowTrackerConnection>();

                var mongoClient = new MongoClient(
                    options.ConnectionString);

                var mongoDatabase = mongoClient.GetDatabase(
                    options.DatabaseName);

                var show = mongoDatabase.GetCollection<Show>(
                    options.ShowCollectionName);

                return show;
            });

            services.AddScoped<IMongoCollection<Actor>>(_ =>
            {
                var options = configuration.GetSection("TekeverShowsStoreDatabase").Get<ShowTrackerConnection>();

                var mongoClient = new MongoClient(
                    options.ConnectionString);

                var mongoDatabase = mongoClient.GetDatabase(
                    options.DatabaseName);

                var actor = mongoDatabase.GetCollection<Actor>(
                   options.ActorCollectionName);

                return actor;
            });

            services.AddScoped<IMongoCollection<GenreType>>(_ =>
            {
                var options = configuration.GetSection("TekeverShowsStoreDatabase").Get<ShowTrackerConnection>();

                var mongoClient = new MongoClient(
                    options.ConnectionString);

                var mongoDatabase = mongoClient.GetDatabase(
                    options.DatabaseName);

                var genre = mongoDatabase.GetCollection<GenreType>(
                   options.GenreTypeCollectionName);

                return genre;
            });


            services.AddSingleton<IHostEnvironment>(environment);

            return services;
        }
    }
}
