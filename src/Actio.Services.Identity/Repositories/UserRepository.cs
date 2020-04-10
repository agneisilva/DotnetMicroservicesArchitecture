using System;
using System.Threading.Tasks;
using actio.services.identity.Domain.Models;
using MongoDB.Driver;
using System.Linq;
using actio.services.identity.Domain.Repositories;

namespace actio.services.identity.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly IMongoDatabase _database;
        public UserRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<User> GetAsync(Guid id)
            => await Task.FromResult(Collection
                .AsQueryable()
                .FirstOrDefault(x => x.Id == id));

        public async Task<User> GetAsync(string email)
            => await Task.FromResult(Collection
                .AsQueryable()
                .FirstOrDefault(x => x.Email == email.ToLowerInvariant()));

        public async Task AddAsync(User user)
            => await Collection.InsertOneAsync(user);

        private IMongoCollection<User> Collection
            => _database.GetCollection<User>("Users");
    }
}
