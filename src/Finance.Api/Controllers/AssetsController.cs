using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;
using Finance.Common.Commands.Assets;

namespace Finance.Api.Controllers
{
    [Route("Finance/[controller]")]
    public class AssetsController : Controller
    {

        private readonly IBusClient _busClient;
        public AssetsController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]CreateAsset command)
        {
            command.Id = Guid.NewGuid();
            await _busClient.PublishAsync(command);

            return Accepted($"finance/assets/{command.Id}");
        }
    }
}