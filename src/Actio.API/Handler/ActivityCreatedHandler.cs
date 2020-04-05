using System;
using System.Threading.Tasks;
using actio.Common.Events;

namespace actio.API.Handler
{
    public class ActivityCreatedHandler : IEventHandler<ActivityCreated>
    {
        public ActivityCreatedHandler()
        {
        }

        public async Task HandleAsync(ActivityCreated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"activity created: {@event.Name}");
        }
    }
}
