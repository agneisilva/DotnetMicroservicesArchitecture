using System;
using System.Threading.Tasks;
using actio.services.Activities.Domain.Models;

namespace actio.services.Activities.Domain.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> GetAsync(Guid id);
        Task AddAsync(Activity activity);
        Task DeleteAsync(Guid id);
    }
}
