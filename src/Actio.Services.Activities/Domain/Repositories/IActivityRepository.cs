using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace actio.services.Activities.Domain.Repositories
{
    public interface IActivityRepository
    {
        Task<Activity> GetAsync(Guid id);
        Task AddAsync(Activity activity);
        Task DeleteAsync(Guid id);
    }
}
