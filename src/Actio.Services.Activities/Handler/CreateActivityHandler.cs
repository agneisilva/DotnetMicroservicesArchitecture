using System;
using System.Threading.Tasks;
using actio.Common.Events;
using Actio.Common.Commands;
using RawRabbit;

namespace actio.services.activities.Handler
{
    public class CreateActivityHandler : ICommandHandler<CreateActivity>
    {
        private readonly IBusClient _busClient;

        public CreateActivityHandler(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public async Task HandleAsync(CreateActivity command)
        {
            Console.WriteLine($"Creating Activities: { command.Name }");
            await _busClient.PublishAsync(new ActivityCreated(command.Id, command.UserId, command.Category, command.Name, command.Description));
        }
    }
}
