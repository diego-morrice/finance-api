using Finance.Common.Events.Assets;
using Finance.Common.ServiceBus;

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
