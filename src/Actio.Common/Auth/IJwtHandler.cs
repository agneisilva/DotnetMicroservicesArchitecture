using System;
using Microsoft.IdentityModel.JsonWebTokens;

namespace actio.Common.Auth
{
    public interface IJwtHandler
    {
        JsonWebToken Create(Guid userId);
    }
}
