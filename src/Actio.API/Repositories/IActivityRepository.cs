using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using actio.API.Domain.Models;

namespace actio.API.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> GetAsync(Guid id);
        Task<IEnumerable<Activity>> BrowseAsync(Guid userId);
        Task AddAsync(Activity activity);
    }
}
