using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using actio.services.Activities.Domain.Models;

namespace actio.services.Activities.Domain.Repositories
{
    public interface ICategoryRepository
    {
        Task<Category> GetAsync(string name);
        Task<IEnumerable<Category>> BrowseAsync();
        Task AddAsync(Category category);
    }
}
