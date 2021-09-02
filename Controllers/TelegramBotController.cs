using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Teledoro.Interfaces;

namespace Teledoro.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelegramBotController : ControllerBase
    {
        private ITelegramBotClientWrapper client;

        public TelegramBotController(ITelegramBotClientWrapper client)
        {
            this.client = client;
        }
        
        [HttpPost("{token}")]
        public async Task<ActionResult> Post(string token)
        {
            using var sr = new StreamReader(Request.Body);
            var bodyContent =  await sr.ReadToEndAsync();

            await client.ReceiveUpdate(token, bodyContent);

            return Ok();
        }
    }
}