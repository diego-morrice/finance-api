using Microsoft.AspNetCore.Hosting;
using RawRabbit;

namespace Finance.Common.ServiceBus.RabbitMq
{
    public class RabbitHostBuilder : BuilderBase
        {
            private readonly IWebHost _webHost;
            private IBusClient _bus;

            public RabbitHostBuilder(IWebHost webHost)
            {
                this._webHost = webHost;
            }

            public RabbitBusBuilder UseRabbitMq()
            {
                _bus = (IBusClient)_webHost.Services.GetService(typeof(IBusClient));
                return new RabbitBusBuilder(_webHost, _bus);
            }

            public override ServiceHost Build()
            {
                return new ServiceHost(_webHost);
            }
        }

}