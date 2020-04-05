using RawRabbit;
using Actio.Common.Commands;
using Actio.Common.Events;
using System.Threading.Tasks;
using actio.Common.Events;
using RawRabbit.Pipe;
using System.Reflection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RawRabbit.Instantiation;
using RawRabbit.Configuration;

namespace Actio.Common.RabbitMQ
{
    public static class Extesion
    {
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus,
            Commands.ICommandHandler<TCommand> handler) where TCommand : ICommand
            => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
                                          ctx => ctx.UseSubscribeConfiguration(
                                                 cfg => cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))));

        public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus,
            actio.Common.Events.IEventHandler<TEvent> handler) where TEvent : IEvent
            => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
                                          ctx => ctx.UseSubscribeConfiguration(
                                                 cfg => cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));

        private static string GetQueueName<TCommand>()
            => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(TCommand).Name}";

        public static void AddRabbitMQ(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var option = new RawRabbitConfiguration();
            var section = configuration.GetSection("Rabbitmq");
            section.Bind(option);
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = option
            });
            serviceCollection.AddSingleton<IBusClient>(_ => client);
        }
    }
}