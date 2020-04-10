using System;
using System.Threading.Tasks;
using actio.services.identity.Domain.Models;

namespace actio.services.identity.Domain.Repositories
{
    public interface IUserRepository
    {
        Task<User> GetAsync(Guid id);
        Task<User> GetAsync(string email);
        Task AddAsync(User user);
    }
}
