using Microsoft.AspNetCore.Hosting;
using RawRabbit;
using Finance.Common.Commands.Infertaces;
using Finance.Common.Events.Interfaces;
using Finance.Common.ServiceBus.RabbitMq.Extensions;

namespace Finance.Common.ServiceBus.RabbitMq
{
    public class RabbitBusBuilder : BuilderBase
    {

        private readonly IWebHost _webHost;
        private IBusClient _bus;

        public RabbitBusBuilder(IWebHost webHost, IBusClient bus)
        {
            this._webHost = webHost;
            this._bus = bus;
        }

        public RabbitBusBuilder SubscribeToCommand<TCommand>() where TCommand : ICommand
        {
            var handler = (ICommandHandler<TCommand>)_webHost.Services
            .GetService(typeof(ICommandHandler<TCommand>));
            _bus.WithCommandHandlerAsync(handler);

            return this;
        }

        public RabbitBusBuilder SubscribeToEvent<TEvent>() where TEvent : IEvent
        {
            var handler = (IEventHandler<TEvent>)_webHost.Services
            .GetService(typeof(IEventHandler<TEvent>));
            _bus.WithEventHandlerAsync(handler);

            return this;
        }

        public override ServiceHost Build()
        {
            return new ServiceHost(_webHost);
        }
    }
}