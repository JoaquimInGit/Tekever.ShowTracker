using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tekever.ShowTracker.Domain.Domain;
using Tekever.ShowTracker.Repository.Contexts;

namespace Tekever.ShowTracker.PersistenceTests
{
	public class ObjectDatabaseTestConnection
	{


        ShowTrackerConnection options = new ShowTrackerConnection
        {
            ConnectionString = "mongodb://user:password@localhost:27018",
            DatabaseName = "ShowTracker",
            ShowCollectionName = "show"
        };

        public IMongoCollection<Show> showCollection;

        public ObjectDatabaseTestConnection()
        {
            var mongoClient = new MongoClient(options.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(options.DatabaseName);

            showCollection = mongoDatabase.GetCollection<Show>(options.ShowCollectionName);

            var config = new Mock<IConfiguration>();
           
        }

    }
}
