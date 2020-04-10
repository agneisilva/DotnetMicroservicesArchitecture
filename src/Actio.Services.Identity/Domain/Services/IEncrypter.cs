using System;
namespace actio.services.identity.Domain.Services
{
    public interface IEncrypter
    {
        string GetSalt();
        string GetHash(string value, string salt);
    }
}
