using System;
using System.Threading.Tasks;
using actio.services.Activities.Domain.Models;
using actio.services.Activities.Domain.Repositories;
using MongoDB.Driver;
using System.Linq;

namespace actio.services.Activities.Repositories
{
    public class ActivityRepository : IActivityRepository
    {
        private readonly IMongoDatabase _database;

        public ActivityRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Activity> GetAsync(Guid id)
            => await Task.FromResult(Collection
                .AsQueryable()
                .FirstOrDefault(x => x.Id == id));

        public async Task AddAsync(Activity activity)
            => await Collection.InsertOneAsync(activity);

        public async Task DeleteAsync(Guid id)
            => await Collection.DeleteOneAsync(x => x.Id == id);

        private IMongoCollection<Activity> Collection
            => _database.GetCollection<Activity>("Activities");
    }
}
