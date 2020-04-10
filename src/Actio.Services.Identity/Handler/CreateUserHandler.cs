using System;
using System.Threading.Tasks;
using Actio.Common.Commands;

namespace actio.services.identity.Handler
{
    public class CreateUserHandler : ICommandHandler<CreateUser>
    {
        public Task HandleAsync(CreateUser command)
        {
            throw new NotImplementedException();
        }
    }
}
