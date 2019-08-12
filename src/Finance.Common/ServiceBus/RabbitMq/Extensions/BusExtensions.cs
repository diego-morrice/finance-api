using System.Reflection;
using System.Threading.Tasks;
using RawRabbit;
using Finance.Common.Commands.Infertaces;
using Finance.Common.Events.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using RawRabbit.Instantiation;

namespace Finance.Common.ServiceBus.RabbitMq.Extensions
{
    public static class BusExtensions
    {
        public static Task WithCommandHandlerAsync<TCommand>(this IBusClient bus,
        ICommandHandler<TCommand> handler) where TCommand : ICommand 
        => bus.SubscribeAsync<TCommand>(msg => handler.HandleAsync(msg),
        ctx => ctx.UseSubscribeConfiguration(cfg => 
        cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TCommand>()))));

         public static Task WithEventHandlerAsync<TEvent>(this IBusClient bus,
        IEventHandler<TEvent> handler) where TEvent : IEvent 
        => bus.SubscribeAsync<TEvent>(msg => handler.HandleAsync(msg),
        ctx => ctx.UseSubscribeConfiguration(cfg => 
        cfg.FromDeclaredQueue(q => q.WithName(GetQueueName<TEvent>()))));

        public static void AddRabbitMq(this IServiceCollection service, IConfiguration config)
        {
            var options = new RabbitMqOptions();
            var section = config.GetSection("rabbitMq");
            section.Bind(options);
            var client = RawRabbitFactory.CreateSingleton(new RawRabbitOptions
            {
                ClientConfiguration = options
            });

            service.AddSingleton<IBusClient>(_ => client);
        }

        private static string GetQueueName<T>() 
        => $"{Assembly.GetEntryAssembly().GetName()}/{typeof(T).Name}";
        
    }
}