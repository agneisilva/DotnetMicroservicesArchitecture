using System.Threading.Tasks;
using Actio.Common.Commands;
using Microsoft.AspNetCore.Mvc;
using RawRabbit;

namespace actio.API.Controllers
{
    [Route("[controller]")]
    public class ActivitiesController : Controller
    {
        private readonly IBusClient _busClient;

        public ActivitiesController(IBusClient busClient)
        {
            _busClient = busClient;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateActivity command)
        {
            await _busClient.PublishAsync(command);

            return Accepted($"activities/{command.Id}");
        }
    }
}
