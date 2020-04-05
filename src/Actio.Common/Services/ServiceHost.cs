using Microsoft.AspNetCore.Hosting;
using System;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore;
using RawRabbit;
using Actio.Common.Commands;
using Actio.Common.Events;
using Actio.Common.RabbitMQ;
using actio.Common.Events;

namespace Actio.Common.Services
{
    public class ServiceHost : IServiceHost
    {
        private readonly IWebHost _webHost;

        public ServiceHost(IWebHost webHost)
        {
            _webHost = webHost;
        }

        public void Run() => _webHost.Run();

        public static HostBuilder Create<Startup>(string[] args) where Startup : class{
            Console.Title = typeof(Startup).Namespace;
            var config = new ConfigurationBuilder()
                        .AddEnvironmentVariables()
                        .AddCommandLine(args)
                        .Build();
            
            var webhostbuilder = WebHost.CreateDefaultBuilder(args).
                                    UseConfiguration(config).
                                    UseStartup<Startup>();

            return new HostBuilder(webhostbuilder.Build());
        }

        public abstract class BuilderBase {
            public abstract ServiceHost Build();
        }

        public class HostBuilder : BuilderBase
        {
            private readonly IWebHost _webHost;
            private IBusClient _bus;


            public HostBuilder(IWebHost webHost)
            {
                _webHost = webHost;
            }

            public BusBuilder UseRabbitMQ()
            {
                _bus = (IBusClient)_webHost.Services.GetService(typeof(IBusClient));

                return new BusBuilder(_webHost, _bus);
            }

            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }
        }

        public class BusBuilder : BuilderBase{
            private readonly IWebHost _webHost;
            private readonly IBusClient _bus;

            public BusBuilder(IWebHost webHost, IBusClient bus)
            {
                _webHost = webHost;
                _bus = bus;
            }

            public BusBuilder SubscriberToCommand<TCommand>() where TCommand : ICommand
            {
                var handler =   (Commands.ICommandHandler<ICommand>)_webHost.Services.GetService(typeof(Commands.ICommandHandler<ICommand>));
                _bus.WithCommandHandlerAsync(handler);
                return this;
            }

            public BusBuilder SubscriberToEvent<TEvent>() where TEvent : IEvent
            {
                var handler =   (actio.Common.Events.IEventHandler<IEvent>)_webHost.Services.GetService(typeof(actio.Common.Events.IEventHandler<IEvent>));
                _bus.WithEventHandlerAsync(handler);
                return this;
            }
            
            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }
        }
    }
}