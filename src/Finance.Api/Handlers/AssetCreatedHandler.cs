using System;
using System.Threading.Tasks;
using Finance.Common.Events.Assets;
using Finance.Common.Events.Interfaces;

namespace Finance.Api.Handlers
{
    public class AssetCreatedHandler : IEventHandler<AssetCreated>
    {
        public async Task HandleAsync(AssetCreated @event)
        {
            await Task.CompletedTask;
            Console.WriteLine($"Asset Created: {@event.Name}");
        }
    }
}