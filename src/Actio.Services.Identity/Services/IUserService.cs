using System;
using System.Threading.Tasks;
using actio.Common.Auth;

namespace actio.services.identity.Services
{
    public interface IUserService
    {
        Task RegisterAsync(string email, string password, string name);
        Task<JsonWebToken> LoginAsync(string email, string password);
    }
}
