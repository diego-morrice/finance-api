using Finance.Common.Commands.Assets;
using Finance.Common.ServiceBus;
using Microsoft.AspNetCore.Hosting;

namespace Finance.Services.Assets
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ServiceHost.Create<Startup>(args)
            .UseRabbitMq()
            .SubscribeToCommand<CreateAsset>()
            .Build()
            .RunAsync();    
        }
    }
}
