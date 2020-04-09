using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using actio.services.Activities.Domain.Models;
using actio.services.Activities.Domain.Repositories;
using MongoDB.Driver;

namespace actio.services.Activities.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly IMongoDatabase _database;

        public CategoryRepository(IMongoDatabase database)
        {
            _database = database;
        }

        public async Task<Category> GetAsync(string name)
            => await Task.FromResult(Collection
                .AsQueryable()
                .FirstOrDefault(x => x.Name == name.ToLowerInvariant()));

        public async Task<IEnumerable<Category>> BrowseAsync()
            => await Collection
                .AsQueryable()
                .ToListAsync();

        public async Task AddAsync(Category category)
            => await Collection.InsertOneAsync(category);

        private IMongoCollection<Category> Collection
            => _database.GetCollection<Category>("Categories");
    }
}
