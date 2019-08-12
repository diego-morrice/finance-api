using System.Threading.Tasks;
using RawRabbit;
using Finance.Common.Commands.Infertaces;
using Finance.Common.Events.Assets;
using Finance.Common.Commands.Assets;
using System;

namespace Finance.Services.Assets.Handlers
{
    public class CreateAssetHandler : ICommandHandler<CreateAsset>
    {

        private readonly IBusClient _busClient;

        public CreateAssetHandler(IBusClient busClient)
        {
            _busClient = busClient;
        }

        public async Task HandleAsync(CreateAsset command)
        {
           Console.WriteLine($"Creating asset: {command.Name}");
           await _busClient.PublishAsync(ToAsset(command));
        }

        private AssetCreated ToAsset(CreateAsset command)
        {
            return new AssetCreated(command.Id, command.Name, command.Symbol
            , command.Type, command.Market, command.ISIN, command.CUSIP
            , command.Underlying, command.Class);
        }
    }
}