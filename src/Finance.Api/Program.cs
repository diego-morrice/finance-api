using Finance.Common.Events.Assets;
using Finance.Common.ServiceBus;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Finance.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
            .UseRabbitMq()
            .SubscribeToEvent<AssetCreated>()
            .Build()
            .RunAsync();            
        }       
    }
}
